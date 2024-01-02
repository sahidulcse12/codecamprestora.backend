using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Domain.Entities;

namespace CodeCampRestora.Application.Features.Images.Commands.CreateImage;

public class CreateImageCommandHandler : ICommandHandler<CreateImageCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateImageCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateImageCommand request, CancellationToken cancellationToken)
    {
        var image = new Image {
            Name = request.Name,
            Type = request.Type,
            DataAsBase64 = request.DataAsBase64,
            SizeInBytes = request.SizeInBytes
        };

        await _unitOfWork.Images.AddAsync(image);
        await _unitOfWork.SaveChangesAsync();
    }
}