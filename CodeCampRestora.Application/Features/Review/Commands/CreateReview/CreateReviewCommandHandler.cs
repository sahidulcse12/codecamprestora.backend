using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Features.Images.Commands.CreateImage;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Entities.Review;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.Features.Review.Commands.CreateReview
{

    public class CreateReviewCommandHandler : ICommandHandler<Images.Commands.CreateImage.CreateReviewCommand, IResult<Guid>>
    {
        private readonly IImageService _imageService;

        public CreateReviewCommandHandler(IImageService imageService)
        {
            _imageService = imageService;
        }

        public async Task<IResult<Guid>> Handle(Images.Commands.CreateImage.CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var imageEO = request.Adapt<Review>();

            var result = await _imageService.UploadImageAsync(imageEO);
            return result;
        }
    }
}
