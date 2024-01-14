using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.Reviews.Queries.GetAllReview
{
    public record GetAllReviewQuery : IQuery<IResult<List<ReviewDTO>>>
    {
    }
}
