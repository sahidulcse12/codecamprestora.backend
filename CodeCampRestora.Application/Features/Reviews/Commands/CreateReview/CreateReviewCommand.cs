using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
namespace CodeCampRestora.Application.Features.Reviews.Commands.CreateReview
{
    public class CreateReviewCommand : ICommand<IResult<ReviewDTO>>
    {
        public Guid ReviewId { get; set; }
        public Guid BranchId { set; get; }
        public required string Description { set; get; }
        public required int Rating { set; get; }
        public Guid OrderId { set; get; }
    }
}
