using Microsoft.AspNetCore.Mvc;
using IResult = CodeCampRestora.Application.Models.IResult;
using CodeCampRestora.Application.Features.Auths.Commands.Login.CreateLogin;
using CodeCampRestora.Application.Features.Auths.Commands.Signup.CreateSignup;
using CodeCampRestora.Application.Features.Auths.Commands.RefreshToken.CreateRefreshToken;

namespace CodeCampRestora.Api.Controllers.V1;

[ApiController]
public class AuthenticationController : ApiBaseController
{
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

    [HttpPost("refresh")]
    public async Task<IResult> RefreshToken(CreateRefreshTokenCommand command)
    {
        var result = await Sender.Send(command);
        return result;
    }
}
