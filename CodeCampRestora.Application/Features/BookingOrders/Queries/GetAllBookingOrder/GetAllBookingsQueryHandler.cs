using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Entities.BookingOrders;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.Features.BookingOrders.Queries.GetAllBookingOrder
{
    public class GetAllBookingsQueryHandler : IQueryHandler<GetAllBookingsQuery, IResult<List<BookingOrderDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllBookingsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task<IResult<List<BookingOrderDTO>>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.BookingOrders.IncludeProps(entity => entity.OrderItems).AsQueryable().ToListAsync();
            var bookingOrdersDto = orders.Adapt<List<BookingOrderDTO>>();
            return Result<List<BookingOrderDTO>>.Success(bookingOrdersDto);
        }
    }
}
