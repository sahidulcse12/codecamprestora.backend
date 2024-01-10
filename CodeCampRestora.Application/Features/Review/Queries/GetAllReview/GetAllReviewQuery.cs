using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.Features.Review.Queries.GetAllReview
{
    public record GetAllReviewQuery:IQuery<IResult<List<ReviewDTO>>>
    {
    }
}
