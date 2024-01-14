using Mapster;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;

namespace CodeCampRestora.Application.Features.User.Commands.UserSignup.CreateUserSignup;

public class CreateUserSignupCommandHandler : ICommandHandler<CreateUserSignupCommand, IResult>
{
    private readonly IIdentityService _identityService;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserSignupCommandHandler(
        IIdentityService identityService,
        IUnitOfWork unitOfWork
        )
    {
        _identityService = identityService;
        _unitOfWork = unitOfWork;
    }

    public Task<IResult> Handle(CreateUserSignupCommand request, CancellationToken cancellationToken)
    {
        var registerMobileUserDto = request.Adapt<RegisterMobileUserDTO>();
        var result = _identityService.RegisterMobileUserAsync(registerMobileUserDto);

        return result;
    }
}
