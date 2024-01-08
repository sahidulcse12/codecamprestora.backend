using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Exceptions;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.Features.BookingOrders.Commands.UpdateBookingOrder
{
    public class UpdateBookingOrderCommandHandler : IRequestHandler<UpdateBookingOrderCommand, BookingOrderDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateBookingOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task<BookingOrderDTO> Handle(UpdateBookingOrderCommand request, CancellationToken cancellationToken)
        {

            var order = await _unitOfWork.BookingOrders.GetByIdAsync(request.Id);
            if (order == null)
            {
                throw new ResourceNotFoundException("Not Found the Brach");
            }

            order.OrderStatus = request.OrderStatus;
            await _unitOfWork.BookingOrders.UpdateAsync(request.Id, order);
            await _unitOfWork.SaveChangesAsync();

            var orderDto = order.Adapt<BookingOrderDTO>();
            return orderDto;
        }
    }
}
