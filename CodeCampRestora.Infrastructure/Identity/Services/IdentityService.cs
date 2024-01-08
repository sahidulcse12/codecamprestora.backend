using System.Security.Claims;
using CodeCampRestora.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using CodeCampRestora.Domain.Identity;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using Microsoft.Extensions.Configuration;
using CodeCampRestora.Application.Attributes;
using IResult = CodeCampRestora.Application.Models.IResult;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;

namespace CodeCampRestora.Infrastructure.Identity.Services;

[ScopedLifetime]
public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly IApplicationDbContext _dbContext;
    private readonly TokenValidationParameters _tokenValidationParameters;

    public IdentityService(
            IApplicationDbContext dbContext,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole<Guid>> roleManager,
            TokenValidationParameters tokenValidationParameters,
            IConfiguration configuration)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _dbContext = dbContext;
        _tokenValidationParameters = tokenValidationParameters;
    }

    public async Task<IResult> RegisterUserAsync(RegisterUserDTO registerUserDto)
    {
        var user = await _userManager.FindByEmailAsync(registerUserDto.Email);
        if (user is not null)
        {
            return Result.Failure(
                StatusCodes.Status403Forbidden,
                AuthErrors.UserExists);
        }

        var newuser = new ApplicationUser
        {
            FirstName = registerUserDto.FirstName,
            LastName = registerUserDto.LastName,
            Email = registerUserDto.Email,
            UserName = registerUserDto.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
        };

        var result = await _userManager.CreateAsync(newuser, registerUserDto.Password);
        if (!result.Succeeded)
        {
            return Result.Failure(
                StatusCodes.Status500InternalServerError,
                AuthErrors.UserCreationFailed
            );
        }

        var createdUser = await _userManager.FindByEmailAsync(registerUserDto.Email);
        var role = await _roleManager.FindByNameAsync(registerUserDto.RoleType.ToString());

        if (createdUser is null || role is null)
        {
            return Result.Failure(
                StatusCodes.Status404NotFound,
                AuthErrors.RoleNotFound
            );
        }

        await _userManager.AddToRoleAsync(createdUser, role.Name!);
        return Result.Success();
    }

    public async Task<IResult> AuthenticateUserAsync(LoginDTO loginDto)
    {
        var user = await _userManager.FindByNameAsync(loginDto.UserName);
        if(user is null)
        {
            return AuthResult.Failure(
                StatusCodes.Status404NotFound,
                AuthErrors.UserNotFound
            );
        }

        var isPasswordVerified = await _userManager.CheckPasswordAsync(user, loginDto.Password);
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

    public async Task<IResult> RefreshToken(string accessToken, Guid refreshToken, CancellationToken cancellationToken)
    {
        var (isValid, claimsIdentity) = await GetPrincipalFromExpiredTokenAsync(accessToken);

        if(!isValid) return AuthResult.Failure(AuthErrors.InvalidToken);

        var expiry = claimsIdentity.FindFirst(JwtRegisteredClaimNames.Exp)?.Value;
        var userId = claimsIdentity.FindFirst(JwtRegisteredClaimNames.Sid)?.Value;
        var jwtId = claimsIdentity.Claims.SingleOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Jti)?.Value;

        if(string.IsNullOrEmpty(expiry)
            || string.IsNullOrEmpty(jwtId)
            || string.IsNullOrEmpty(userId))
            return AuthResult.Failure(AuthErrors.ClaimsNotFound);

        var isExpired = DateTime.Parse(expiry) < DateTime.Now;
        if(!isExpired) return AuthResult.Success(accessToken, refreshToken.ToString());

        var storedRefreshToken = await _dbContext.DbSet<RefreshToken>().SingleOrDefaultAsync(r => r.Id == refreshToken, cancellationToken);
        if(storedRefreshToken is null) return AuthResult.Failure(AuthErrors.InvalidToken);

        if(storedRefreshToken.Expiry < DateTime.Now) return AuthResult.Failure(AuthErrors.Expired);

        if(storedRefreshToken.Used) return AuthResult.Failure(AuthErrors.TokenIsUsed);

        storedRefreshToken.MarkIsUsed(true);
        _dbContext.DbSet<RefreshToken>().Update(storedRefreshToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        var user = await _userManager.FindByIdAsync(userId);
        if(user is null) return AuthResult.Failure(AuthErrors.UserNotFound);

        return await GenerateTokenAsync(user);
    }

    private async Task<(bool IsValid, ClaimsIdentity ClaimsIdentity)> GetPrincipalFromExpiredTokenAsync(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var result = await tokenHandler.ValidateTokenAsync(token, _tokenValidationParameters);

        if(result.IsValid
            && result.SecurityToken is JwtSecurityToken jwtSecurityToken
            && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256.ToString()))
        {
           return (IsValid: false, ClaimsIdentity: result.ClaimsIdentity);
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
            new(JwtRegisteredClaimNames.Email, user.Email!)
        };

        var userRoles = await _userManager.GetRolesAsync(user);
        userRoles.ToList().ForEach(role => authClaims.Add(new(ClaimTypes.Role, role)));

        var securityToken = new TokenBuilder()
            .AddIssuer(_configuration["JWT:ValidIssuer"]!)
            .AddAudience(_configuration["JWT:ValidAudience"]!)
            .AddExpiry(DateTime.Now.AddDays(2))
            .AddClaims(authClaims)
            .AddKey(_configuration["JWT:Secret"]!)
            .Build();
        var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

        var refreshToken = new RefreshToken {
            JwtId = jwtId,
            ApplicationUserId = user.Id,
            Expiry = DateTime.Now.AddDays(30).ToUniversalTime()
        };
        await _dbContext.DbSet<RefreshToken>().AddAsync(refreshToken);
        await _dbContext.SaveChangesAsync();

        return AuthResult.Success(token, refreshToken.Id.ToString());
    }
}