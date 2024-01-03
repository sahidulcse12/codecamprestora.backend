using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.Models;
using MediatR;

namespace CodeCampRestora.Application.Features.Images.Commands.CreateImage;

public class CreateImageCommandHandler : ICommandHandler<CreateImageCommand, IResult>
{
    private readonly IImageService _imageService;

    public CreateImageCommandHandler(IImageService imageService)
    {
        _imageService = imageService;
    }

    public async Task<IResult> Handle(CreateImageCommand request, CancellationToken cancellationToken)
    {
        var imageEO = new Image
        {
            Name = request.Name,
            Type = request.Type,
            Base64 = request.Base64
        };

        var result = await _imageService.UploadImageAsync(imageEO);
        return result;
    }
}