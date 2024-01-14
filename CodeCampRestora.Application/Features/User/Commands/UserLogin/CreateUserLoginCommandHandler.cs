using Mapster;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;

namespace CodeCampRestora.Application.Features.User.Commands.UserLogin;

public class CreateUserLoginCommandHandler : ICommandHandler<CreateUserLoginCommand, IResult>
{
    private readonly IIdentityService _identityService;

    public CreateUserLoginCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    public async Task<IResult> Handle(CreateUserLoginCommand request, CancellationToken cancellationToken)
    {
        var mobileUserLoginDto = request.Adapt<MobileUserLoginDto>();
        var result = await _identityService.AuthenticateMobileUserAsync(mobileUserLoginDto);

        return result;
    }
}

