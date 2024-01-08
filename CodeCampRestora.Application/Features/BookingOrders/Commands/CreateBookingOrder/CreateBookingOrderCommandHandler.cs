using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Domain.Entities.BookingOrders;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.Features.BookingOrders.Commands.CreateBookingOrder
{
    public class CreateBookingOrderCommandHandler : IRequestHandler<CreateBookingOrderCommand, BookingOrderDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateBookingOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task<BookingOrderDTO> Handle(CreateBookingOrderCommand request, CancellationToken cancellationToken)
        {
            var BookingOrderEO = request.Adapt<BookingOrder>();

            await _unitOfWork.BookingOrders.AddAsync(BookingOrderEO);
            await _unitOfWork.SaveChangesAsync();

            var BookingOrderDto = BookingOrderEO.Adapt<BookingOrderDTO>();
            return BookingOrderDto;
        }
    }
}
