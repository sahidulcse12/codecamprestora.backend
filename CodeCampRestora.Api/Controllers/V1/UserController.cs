using Microsoft.AspNetCore.Mvc;
using IResult = CodeCampRestora.Application.Models.IResult;
using CodeCampRestora.Application.Features.Auths.Commands.RefreshToken.CreateRefreshToken;
using CodeCampRestora.Application.Features.User.Commands.UserSignup.CreateUserSignup;
using CodeCampRestora.Application.Features.User.Commands.UserLogin;

namespace CodeCampRestora.Api.Controllers.V1;

[ApiController]
public class UserController : ApiBaseController
{
    [HttpPost("userRegister")]
    public async Task<IResult> Register(CreateUserSignupCommand command)
    {
        var result = await Sender.Send(command);
        return result;
    }

    [HttpPost("login")]
    public async Task<IResult> Login([FromBody] CreateUserLoginCommand command)
    {
        var result = await Sender.Send(command);
        return (IResult)result;
    }

    [HttpPost("refresh")]
    public async Task<IResult> RefreshToken(CreateRefreshTokenCommand command)
    {
        var result = await Sender.Send(command);
        return (IResult)result;
    }
}
