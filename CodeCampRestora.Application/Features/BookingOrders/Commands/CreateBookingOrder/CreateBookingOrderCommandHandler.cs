using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
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
    public class CreateBookingOrderCommandHandler : ICommandHandler<CreateBookingOrderCommand, IResult<BookingOrderDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateBookingOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task<IResult<BookingOrderDTO>> Handle(CreateBookingOrderCommand request, CancellationToken cancellationToken)
        {
            var bookingOrderEO = request.Adapt<BookingOrder>();

            await _unitOfWork.BookingOrders.AddAsync(bookingOrderEO);
            await _unitOfWork.SaveChangesAsync();

            var bookingOrderDto = bookingOrderEO.Adapt<BookingOrderDTO>();
            return Result<BookingOrderDTO>.Success(bookingOrderDto);
        }
    }
}
