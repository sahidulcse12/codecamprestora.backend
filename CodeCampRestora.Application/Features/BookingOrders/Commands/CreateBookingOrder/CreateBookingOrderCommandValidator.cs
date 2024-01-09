using CodeCampRestora.Application.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.Features.BookingOrders.Commands.CreateBookingOrder
{
    public class CreateBookingOrderCommandValidator : ApplicationValidator<CreateBookingOrderCommand>
    {
        public CreateBookingOrderCommandValidator()
        {
            RuleFor(item => item.CustomerName).NotEmpty().WithMessage("Customer Name can't be empty");
            RuleFor(item => item.CustomerMobileNumber).NotEmpty().WithMessage("Customer Mobile No. can't be empty");
            RuleFor(item => item.NoOfSeats).NotEmpty().WithMessage("No. of seat can't be empty");
        }
    }
}
