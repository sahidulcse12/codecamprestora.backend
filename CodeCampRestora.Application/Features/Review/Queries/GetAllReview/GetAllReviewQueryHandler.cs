﻿using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.Features.Review.Queries.GetAllReview
{
    public class GetAllReviewQueryHandler : IQueryHandler<GetAllReviewQuery, IResult<List<ReviewDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllReviewQueryHandler(IUnitOfWork unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<IResult<List<ReviewDTO>>> Handle(GetAllReviewQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _unitOfWork.Reviews.GetAllAsync();
            var reviewsDto = reviews.Adapt<List<ReviewDTO>>();
            return Result<List<ReviewDTO>>.Success(reviewsDto);
        }
    }
}
