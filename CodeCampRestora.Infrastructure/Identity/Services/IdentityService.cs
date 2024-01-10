using System.Data;
using System.Security.Claims;
using CodeCampRestora.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using CodeCampRestora.Domain.Identity;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using Microsoft.Extensions.Configuration;
using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Infrastructure.Constants;
using CodeCampRestora.Infrastructure.Identity.Interfaces;
using IResult = CodeCampRestora.Application.Models.IResult;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;

namespace CodeCampRestora.Infrastructure.Identity.Services;

[ScopedLifetime]
public class IdentityService : IIdentityService
{
    private readonly IDateTimeService _dateTime;
    private readonly IConfiguration _configuration;
    private readonly IApplicationDbContext _dbContext;
    private readonly TokenValidationParameters _tokenValidationParameters;
    private readonly IApplicationUserManagerAdapter _applicationUserManager;
    private readonly IApplicationRoleManagerAdapter _applicationRoleManager;

    public IdentityService(
            IApplicationDbContext dbContext,
            IDateTimeService dateTimeService,
            IConfiguration configuration,
            IApplicationUserManagerAdapter applicationUserManager,
            IApplicationRoleManagerAdapter applicationRoleManager,
            TokenValidationParameters tokenValidationParameters)
    {
        _dbContext = dbContext;
        _dateTime = dateTimeService;
        _configuration = configuration;
        _applicationUserManager = applicationUserManager;
        _applicationRoleManager = applicationRoleManager;
        _tokenValidationParameters = tokenValidationParameters;
    }

    public async Task<IResult> RegisterUserAsync(RegisterUserDTO registerUserDto)
    {
        var user = await _applicationUserManager.FindByEmailAsync(registerUserDto.Email);
        if (user is not null)
        {
            return AuthResult.Failure(
                StatusCodes.Status403Forbidden,
                AuthErrors.UserExists);
        }

        var newuser = new ApplicationUser
        {
            FirstName = registerUserDto.FirstName,
            LastName = registerUserDto.LastName,
            Email = registerUserDto.Email,
            UserName = registerUserDto.Email,
        };

        var result = await _applicationUserManager.CreateAsync(newuser, registerUserDto.Password);
        if (!result.Succeeded)
        {
            return Result.Failure(
                StatusCodes.Status500InternalServerError,
                AuthErrors.UserCreationFailed
            );
        }

        var createdUser = await _applicationUserManager.FindByEmailAsync(registerUserDto.Email);
        var role = await _applicationRoleManager.FindByNameAsync(registerUserDto.RoleType.ToString());

        if (createdUser is null || role is null)
        {
            return AuthResult.Failure(
                StatusCodes.Status404NotFound,
                AuthErrors.RoleNotFound
            );
        }

        await _applicationUserManager.AddToRoleAsync(createdUser, role.Name!);
        return Result.Success();
    }

    public async Task<IResult> RegisterMobileUserAsync(RegisterMobileUserDTO registerMobileUserDTO)
    {
        var user = await _applicationUserManager.FindByEmailAsync(registerMobileUserDTO.Email);
        if(user is not null)
        {
            return AuthResult.Failure(
                StatusCodes.Status403Forbidden,
                AuthErrors.UserExists
                );
        }

        var newuser = new ApplicationUser
        {
            FirstName = registerMobileUserDTO.FirstName,
            LastName = registerMobileUserDTO.LastName,
            Email = registerMobileUserDTO.Email,
            UserName = registerMobileUserDTO.Phone,
            PhoneNumber = registerMobileUserDTO.Phone,
        };

        var result = await _applicationUserManager.CreateAsync(newuser, registerMobileUserDTO.Password);
        if (!result.Succeeded)
        {
            return Result.Failure(
                StatusCodes.Status500InternalServerError,
                AuthErrors.UserCreationFailed
                );
        }

        var createdUser = await _applicationUserManager.FindByEmailAsync(registerMobileUserDTO.Email);
        if (createdUser is null)
        {
            return AuthResult.Failure(
                StatusCodes.Status404NotFound,
                AuthErrors.RoleNotFound
            );
        }

        await _applicationUserManager.AddToRoleAsync(createdUser, "User");
        return Result.Success();

    }

    public async Task<IAuthResult> AuthenticateUserAsync(LoginDTO loginDto)
    {
        var user = await _applicationUserManager.FindByNameAsync(loginDto.Username);
        if(user is null)
        {
            return AuthResult.Failure(
                StatusCodes.Status404NotFound,
                AuthErrors.UserNotFound
            );
        }

        var isPasswordVerified = await _applicationUserManager.CheckPasswordAsync(user, loginDto.Password);
        if(!isPasswordVerified)
        {
            return AuthResult.Failure(
                StatusCodes.Status401Unauthorized,
                AuthErrors.LoginError
            );
        }

        var result = await GenerateTokenAsync(user);
        return result;
    }

    public async Task<IAuthResult> AuthenticateMobileUserAsync(MobileUserLoginDto mobileUserLoginDto)
    {
        var user = await _applicationUserManager.FindByNameAsync(mobileUserLoginDto.Phone);
        if (user is null)
        {
            return AuthResult.Failure(
                StatusCodes.Status404NotFound,
                AuthErrors.UserNotFound
            );
        }

        var isPasswordVerified = await _applicationUserManager.CheckPasswordAsync(user, mobileUserLoginDto.Password);
        if (!isPasswordVerified)
        {
            return AuthResult.Failure(
                StatusCodes.Status401Unauthorized,
                AuthErrors.LoginError
            );
        }

        var result = await GenerateTokenAsync(user);
        return result;
    }

    public async Task<IAuthResult> RefreshTokenAsync(string accessToken, string refreshToken, CancellationToken cancellationToken)
    {
        var (isValid, claimsIdentity) = await GetPrincipalFromExpiredTokenAsync(accessToken);
        if(!isValid) return AuthResult.Failure(AuthErrors.InvalidToken);

        var expiryInSeconds = claimsIdentity.FindFirst(JwtRegisteredClaimNames.Exp)?.Value;
        var userId = claimsIdentity.FindFirst(JwtRegisteredClaimNames.Sid)?.Value;
        var jwtId = claimsIdentity.Claims.SingleOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Jti)?.Value;
        var restaurantId = claimsIdentity.Claims.SingleOrDefault(claim => claim.Type == ApplicationConstants.RestaurantIdClaim)?.Value;
        var roles = claimsIdentity.Claims.Where(claim => claim.Type == ClaimTypes.Role).Select(claim => claim.Value);

        if(string.IsNullOrEmpty(expiryInSeconds)
            || string.IsNullOrEmpty(jwtId)
            || string.IsNullOrEmpty(userId)
            || string.IsNullOrEmpty(restaurantId))
            return AuthResult.Failure(AuthErrors.ClaimsNotFound);

        var accessTokenValidationResult = ValidateAccessToken(expiryInSeconds, accessToken, refreshToken, userId, restaurantId, roles);
        if(accessTokenValidationResult.IsSuccess) return accessTokenValidationResult;

        var refreshTokenValidationResult = await ValidateRefreshTokenAsync(jwtId, refreshToken, cancellationToken);
        if(!refreshTokenValidationResult.IsSuccess) return (AuthResult) refreshTokenValidationResult;

        var user = await _applicationUserManager.FindByIdAsync(userId);
        if(user is null) return AuthResult.Failure(AuthErrors.UserNotFound);
        if(user.RestaurantId == new Guid(restaurantId)) return AuthResult.Failure(AuthErrors.InvalidClaim);

        return await GenerateTokenAsync(user);
    }

    private async Task<(bool IsValid, ClaimsIdentity ClaimsIdentity)> GetPrincipalFromExpiredTokenAsync(string accessToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var result = await tokenHandler.ValidateTokenAsync(accessToken, _tokenValidationParameters);

        if(result.IsValid
            && result.SecurityToken is JwtSecurityToken jwtSecurityToken
            && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256.ToString()))
        {
           return (IsValid: true, ClaimsIdentity: result.ClaimsIdentity);
        }

        return (IsValid: false, ClaimsIdentity: new ClaimsIdentity());
    }

    public bool IsTokenValidated(SecurityToken token)
    {
        if(token is JwtSecurityToken securityToken
            && securityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256.ToString()))
        {
            return true;
        }

        return false;
    }

    private async Task<IAuthResult> GenerateTokenAsync(ApplicationUser user)
    {
        var jwtId = Guid.NewGuid();

        var authClaims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sid, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Jti, jwtId.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email!),
            new(ApplicationConstants.RestaurantIdClaim, user.RestaurantId.ToString()),
        };

        var userRoles = await _applicationUserManager.GetRolesAsync(user);
        userRoles.ToList().ForEach(role => authClaims.Add(new(ClaimTypes.Role, role)));

        var securityToken = new TokenBuilder()
            .AddIssuer(_configuration["JWT:ValidIssuer"]!)
            .AddAudience(_configuration["JWT:ValidAudience"]!)
            .AddExpiry(_dateTime.Now.AddMinutes(5))
            .AddNotBefore(_dateTime.Now)
            .AddClaims(authClaims)
            .AddKey(_configuration["JWT:Secret"]!)
            .Build();
        var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

        var refreshToken = new RefreshToken {
            JwtId = jwtId,
            ApplicationUserId = user.Id,
            CreatedDate = _dateTime.Now,
            Expiry = _dateTime.Now.AddDays(30)
        };
        await _dbContext.DbSet<RefreshToken>().AddAsync(refreshToken);
        await _dbContext.SaveChangesAsync();

        return AuthResult.Success(token, refreshToken.Id.ToString(), securityToken.ValidTo,
            user.Id.ToString(), user.RestaurantId.ToString(), userRoles);
    }

    private IAuthResult ValidateAccessToken(string expiryInSeconds, string accessToken,
        string refreshToken, string userId, string restaurantId, IEnumerable<string> roles)
    {
        var expiryDateInUTC = DateTimeOffset.FromUnixTimeSeconds(long.Parse(expiryInSeconds)).UtcDateTime;
        var isExpired = expiryDateInUTC < _dateTime.Now;
        if (!isExpired) return AuthResult.Success(accessToken, refreshToken.ToString(),
            expiryDateInUTC, userId, restaurantId, roles);

        return AuthResult.Failure();
    }

    private async Task<IResult> ValidateRefreshTokenAsync(string accessTokenId, string refreshToken, CancellationToken cancellationToken)
    {
        var storedRefreshToken = await _dbContext
            .DbSet<RefreshToken>()
            .SingleOrDefaultAsync(r => r.Id == new Guid(refreshToken), cancellationToken);

        if(storedRefreshToken is null) return AuthResult.Failure(AuthErrors.InvalidToken);
        if(storedRefreshToken.JwtId != new Guid(accessTokenId)) return AuthResult.Failure(AuthErrors.TokenMismatch);
        if(storedRefreshToken.Expiry < _dateTime.Now) return AuthResult.Failure(AuthErrors.Expired);
        if(storedRefreshToken.Used) return AuthResult.Failure(AuthErrors.TokenIsUsed);

        storedRefreshToken.MarkIsUsed(true);
        _dbContext.DbSet<RefreshToken>().Update(storedRefreshToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}