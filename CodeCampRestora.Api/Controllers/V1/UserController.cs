using Microsoft.AspNetCore.Mvc;
using CodeCampRestora.Application.Features.Auths.Commands.User.UserLogin;
using CodeCampRestora.Application.Features.Auths.Commands.RefreshToken.CreateRefreshToken;
using CodeCampRestora.Application.Features.Auths.Commands.User.UserSignup.CreateUserSignup;

namespace CodeCampRestora.Api.Controllers.V1;

[ApiController]
public class UserController : ApiBaseController
{
    [HttpPost("userRegister")]
    public async Task<IResult> Register(CreateUserSignupCommand command)
    {
        var result = await Sender.Send(command);
        return (IResult)result;
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
