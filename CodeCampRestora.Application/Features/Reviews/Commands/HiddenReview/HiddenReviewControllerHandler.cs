using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using Mapster;
using MediatR;

namespace CodeCampRestora.Application.Features.Reviews.Commands.HiddenReview
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
            var ReviewEO = request.Adapt<Domain.Entities.Review>();

            await _unitOfWork.Reviews.AddAsync(ReviewEO);
            await _unitOfWork.SaveChangesAsync();

            var reviewOrderDto = ReviewEO.Adapt<ReviewDTO>();
            return Result<ReviewDTO>.Success(reviewOrderDto);
        }
    }
}


