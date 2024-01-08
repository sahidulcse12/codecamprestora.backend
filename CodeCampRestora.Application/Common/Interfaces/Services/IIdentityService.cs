using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Common.Interfaces.Services;

public interface IIdentityService
{
    Task<IResult> RegisterUserAsync(RegisterUserDTO registerUserDto);
    Task<IAuthResult> AuthenticateUserAsync(LoginDTO loginDto);
    Task<IAuthResult> RefreshTokenAsync(string accessToken, Guid refreshToken, CancellationToken cancellationToken);
}