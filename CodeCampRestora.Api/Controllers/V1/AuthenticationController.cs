using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CodeCampRestora.Domain.Identity;
using IResult = CodeCampRestora.Application.Models.IResult;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;
using CodeCampRestora.Application.Features.Auths.Commands.Login.CreateLogin;
using CodeCampRestora.Application.Features.Auths.Commands.Signup.CreateSignup;

namespace CodeCampRestora.Api.Controllers.V1;

[ApiController]
public class AuthenticationController : ApiBaseController
{
    private readonly IConfiguration _configuration;
    private readonly IApplicationDbContext _dbContext;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;

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
    public async Task<IResult> Register(CreateSignupCommand command)
    {
        var result = await Sender.Send(command);
        return result;
    }

    [HttpPost("login")]
    public async Task<IResult> Login([FromBody] CreateLoginCommand command)
    {
        var result = await Sender.Send(command);
        return result;
    }
}
