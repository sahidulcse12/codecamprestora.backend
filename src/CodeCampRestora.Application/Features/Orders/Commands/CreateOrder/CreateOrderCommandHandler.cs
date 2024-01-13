using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Entities.Orders;
using Mapster;

namespace CodeCampRestora.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, IResult<OrderDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task<IResult<OrderDTO>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEO = request.Adapt<Order>();

            await _unitOfWork.Orders.AddAsync(orderEO);
            await _unitOfWork.SaveChangesAsync();

            var orderDto = orderEO.Adapt<OrderDTO>();
            return Result<OrderDTO>.Success(orderDto);
        }
    }
}
