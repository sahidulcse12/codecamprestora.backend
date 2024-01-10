using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Common.Interfaces.Services;

public interface IIdentityService
{
    Task<IResult> RegisterUserAsync(RegisterUserDTO registerUserDto);
    Task<IResult> RegisterMobileUserAsync(RegisterMobileUserDTO registerMobileUserDTO);
    Task<IAuthResult> AuthenticateUserAsync(LoginDTO loginDto);
    Task<IAuthResult> AuthenticateMobileUserAsync(MobileUserLoginDto mobileUserLoginDto);
    Task<IAuthResult> RefreshTokenAsync(string accessToken, string refreshToken, CancellationToken cancellationToken);
}