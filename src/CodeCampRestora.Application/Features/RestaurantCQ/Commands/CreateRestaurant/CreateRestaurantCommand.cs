using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;

namespace CodeCampRestora.Application.Features.RestaurantCQ.Commands.CreateRestaurant;

public record CreateRestaurantCommand(string Name, Guid ImageId) : ICommand<IResult<Guid>>;
