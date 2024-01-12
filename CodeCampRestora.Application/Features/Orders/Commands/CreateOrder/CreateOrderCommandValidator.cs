using CodeCampRestora.Application.Common;
using FluentValidation;

namespace CodeCampRestora.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : ApplicationValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(item => item.CustomerName).NotEmpty().WithMessage("Customer Name can't be empty");
            RuleFor(item => item.CustomerMobileNumber).NotEmpty().WithMessage("Customer Mobile No. can't be empty");
            RuleFor(item => item.NoOfSeats).NotEmpty().WithMessage("No. of seat can't be empty");
        }
    }
}
