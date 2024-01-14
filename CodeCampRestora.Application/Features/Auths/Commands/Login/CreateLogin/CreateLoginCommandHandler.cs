using Mapster;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;

namespace CodeCampRestora.Application.Features.Auths.Commands.Login.CreateLogin;

public class CreateLoginCommandHandler : ICommandHandler<CreateLoginCommand, IResult>
{
    private readonly IIdentityService _identityService;

    public CreateLoginCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<IResult> Handle(CreateLoginCommand request, CancellationToken cancellationToken)
    {
        var loginDTO = request.Adapt<LoginDTO>();
        var result = await _identityService.AuthenticatRestaurantOwnerAsync(loginDTO);

        return result;
    }
}