using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.Orders.Queries.GetAllOrder
{
    public record GetAllOrdersQuery : IQuery<IResult<List<OrderDTO>>>
    {
    }
}
