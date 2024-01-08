using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Common.Interfaces.Services;

public interface IIdentityService
{
    Task<IResult> AuthenticateUserAsync(LoginDTO loginDto);
    Task<IResult> RegisterUserAsync(RegisterUserDTO registerUserDto);
}