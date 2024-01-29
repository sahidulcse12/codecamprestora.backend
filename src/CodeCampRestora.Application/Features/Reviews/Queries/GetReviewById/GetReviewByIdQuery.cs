using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.Reviews.Queries.GetReviewById
{
    public class GetReviewByIdQuery : IQuery<IResult<List<ReviewDTO>>>
    {
        public Guid Id { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetReviewByIdQuery(Guid id,int pageNumber, int pageSize)
        {
            Id = id;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
      
       
    }
}
