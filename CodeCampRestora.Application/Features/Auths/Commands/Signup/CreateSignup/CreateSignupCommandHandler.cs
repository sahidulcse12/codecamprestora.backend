using Mapster;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;

namespace CodeCampRestora.Application.Features.Auths.Commands.Signup.CreateSignup;

public class CreateSignupCommandHandler : ICommandHandler<CreateSignupCommand, IResult>
{
    private IIdentityService _identityService;

    public CreateSignupCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public Task<IResult> Handle(CreateSignupCommand request, CancellationToken cancellationToken)
    {
        var registerUserDto = request.Adapt<RegisterUserDTO>();
        var result =_identityService.RegisterUserAsync(registerUserDto);

        return result;
    }
}