using MediatR;
using Mapster;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.Features.RestaurantCQ.Commands.CreateRestaurant;

namespace CodeCampRestora.Application.Features.Auths.Commands.Signup.CreateSignup;

public class CreateSignupCommandHandler : ICommandHandler<CreateSignupCommand, IResult>
{
    private readonly IIdentityService _identityService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;

    public CreateSignupCommandHandler(
        IIdentityService identityService,
        IMediator mediator,
        IUnitOfWork unitOfWork)
    {
        _identityService = identityService;
        _mediator = mediator;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(CreateSignupCommand request, CancellationToken cancellationToken)
    {
        var restaurantResult = await _mediator.Send(new CreateRestaurantCommand("Your restaurant", Guid.NewGuid()));
        if(!restaurantResult.IsSuccess) return restaurantResult;

        var registerUserDTO = request.Adapt<RegisterUserDTO>();
        var result = await _identityService.RegisterRestaurantOwnerAsync(registerUserDTO, restaurantResult.Data);

        return result;
    }
}