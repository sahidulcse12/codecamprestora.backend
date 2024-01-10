﻿using CodeCampRestora.Application.Features.Auths.Commands.Login.CreateLogin;
using CodeCampRestora.Application.Features.Auths.Commands.RefreshToken.CreateRefreshToken;
using CodeCampRestora.Application.Features.Auths.Commands.Signup.CreateSignup;
using CodeCampRestora.Application.Features.Auths.Commands.User.UserLogin;
using CodeCampRestora.Application.Features.Auths.Commands.User.UserSignup.CreateUserSignup;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
