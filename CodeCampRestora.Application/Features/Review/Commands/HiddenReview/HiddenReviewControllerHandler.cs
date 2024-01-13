using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Features.Review.Commands.CreateReview;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CodeCampRestora.Application.Features.Review.Commands.HiddenReview
{
    public class HiddenReviewControllerHandler : ICommandHandler<HiddenReviewCommand, IResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        public HiddenReviewControllerHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        async Task<IResult> IRequestHandler<HiddenReviewCommand, IResult>.Handle(HiddenReviewCommand request, CancellationToken cancellationToken)
        {
            var ReviewEO = request.Adapt<Review1>();

            await _unitOfWork.Reviews.AddAsync(ReviewEO);
            await _unitOfWork.SaveChangesAsync();

            var reviewOrderDto = ReviewEO.Adapt<ReviewDTO>();
            return Result<ReviewDTO>.Success(reviewOrderDto);
        }
    }
}

   
