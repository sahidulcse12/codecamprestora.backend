using CodeCampRestora.Application.Common;
using CodeCampRestora.Application.Features.BookingOrders.Commands.CreateBookingOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.Features.BookingOrders.Commands.UpdateBookingOrder
{
    public class UpdateBookingOrderCommandValidator : ApplicationValidator<UpdateBookingOrderCommand>
    {
        public UpdateBookingOrderCommandValidator()
        {
        }
    }
}
