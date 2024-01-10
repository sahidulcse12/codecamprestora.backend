using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;

namespace CodeCampRestora.Application.Features.Auths.Commands.RefreshToken.CreateRefreshToken;

public class CreateRefreshTokenCommandHandler : ICommandHandler<CreateRefreshTokenCommand, IAuthResult>
{
    private readonly IIdentityService _identityService;

    public CreateRefreshTokenCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<IAuthResult> Handle(CreateRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var result = await _identityService.RefreshTokenAsync(
            request.accessToken,
            request.refreshToken,
            cancellationToken);

        return result;
    }
}