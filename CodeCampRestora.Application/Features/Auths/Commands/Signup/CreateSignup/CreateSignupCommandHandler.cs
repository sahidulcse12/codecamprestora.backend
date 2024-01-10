using Mapster;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.Common.Interfaces.Repositories;

namespace CodeCampRestora.Application.Features.Auths.Commands.Signup.CreateSignup;

public class CreateSignupCommandHandler : ICommandHandler<CreateSignupCommand, IResult>
{
    private readonly IIdentityService _identityService;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSignupCommandHandler(
        IIdentityService identityService,
        IUnitOfWork unitOfWork)
    {
        _identityService = identityService;
        _unitOfWork = unitOfWork;
    }

    public Task<IResult> Handle(CreateSignupCommand request, CancellationToken cancellationToken)
    {
        var registerUserDto = request.Adapt<RegisterUserDTO>();
        var result =_identityService.RegisterUserAsync(registerUserDto);

        return result;
    }
}