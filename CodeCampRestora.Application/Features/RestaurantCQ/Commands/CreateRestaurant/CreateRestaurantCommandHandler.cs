using Mapster;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Infrastructure.Entities;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;

namespace CodeCampRestora.Application.Features.RestaurantCQ.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler : ICommandHandler<CreateRestaurantCommand, IResult<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRestaurantCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<Guid>> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurantModel = request.Adapt<Restaurant>();
        await _unitOfWork.Restaurants.AddAsync(restaurantModel);
        await _unitOfWork.SaveChangesAsync();

        return Result<Guid>.Success(restaurantModel.Id);
    }
}
