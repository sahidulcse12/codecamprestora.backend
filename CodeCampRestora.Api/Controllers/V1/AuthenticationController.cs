using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using CodeCampRestora.Identity;
using Microsoft.AspNetCore.Identity;
using CodeCampRestora.Domain.Identity;
using System.IdentityModel.Tokens.Jwt;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Entities.Authentication.Login;
using IResult = CodeCampRestora.Application.Models.IResult;
using CodeCampRestora.Domain.Entities.Authentication.SignUp;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;

namespace CodeCampRestora.Api.Controllers.V1;

[ApiController]
public class AuthenticationController : ApiBaseController
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly IApplicationDbContext _dbContext;

    public AuthenticationController(
            IApplicationDbContext dbContext,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole<Guid>> roleManager,
            IConfiguration configuration)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _dbContext = dbContext;
    }

    [HttpPost("register")]
    public async Task<IResult> Register([FromBody] RegisterUser registerUser)
    {
        var user = await _userManager.FindByEmailAsync(registerUser.Email);
        if (user is not null)
        {
            return Result.Failure(
                StatusCodes.Status403Forbidden,
                AuthErrors.UserExists);
        }

        var newuser = new ApplicationUser
        {
            FirstName = registerUser.FirstName,
            LastName = registerUser.LastName,
            Email = registerUser.Email,
            UserName = registerUser.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
        };

        var result = await _userManager.CreateAsync(newuser, registerUser.Password);
        if (!result.Succeeded)
        {
            return Result.Failure(
                StatusCodes.Status500InternalServerError,
                AuthErrors.UserCreationFailed
            );
        }

        var createdUser = await _userManager.FindByEmailAsync(registerUser.Email);
        var role = await _roleManager.FindByNameAsync(registerUser.RoleType.ToString());

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

    [HttpPost("login")]
    public async Task<IResult> Login([FromBody] LoginModel loginModel)
    {
        var user = await _userManager.FindByNameAsync(loginModel.UserName);
        if(user is null)
        {
            return AuthResult.Failure(
                StatusCodes.Status404NotFound,
                AuthErrors.UserNotFound
            );
        }

        var isPasswordVerified = await _userManager.CheckPasswordAsync(user, loginModel.Password);
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
