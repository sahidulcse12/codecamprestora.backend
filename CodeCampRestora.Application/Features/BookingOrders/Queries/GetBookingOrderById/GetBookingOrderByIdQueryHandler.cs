using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Exceptions;
using CodeCampRestora.Application.Models;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.Features.BookingOrders.Queries.GetBookingOrderById
{
    public class GetBookingOrderByIdQueryHandler : IQueryHandler<GetBookingOrderByIdQuery, IResult<BookingOrderDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetBookingOrderByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task<IResult<BookingOrderDTO>> Handle(GetBookingOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.BookingOrders.IncludeProp("OrderItems").FirstOrDefaultAsync(x => x.Id == request.Id); 
            if (order == null)
            {
                throw new ResourceNotFoundException("No Order Found");
            }

            var bookingOrderDto = order.Adapt<BookingOrderDTO>();
            return Result<BookingOrderDTO>.Success(bookingOrderDto);

        }
    }
}
