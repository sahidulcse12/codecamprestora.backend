using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.Models;
using Microsoft.EntityFrameworkCore;


namespace CodeCampRestora.Application.Features.Branches.Commands.UploadBranchImage;

public class UploadBranchImageCommandHandler : ICommandHandler<UploadBranchImageCommand, IResult>
{
    public readonly IUnitOfWork _unitOfWork;
    public readonly IImageService _imageService;
    public UploadBranchImageCommandHandler(IUnitOfWork unitOfWork, IImageService imageService)
    {
        _unitOfWork = unitOfWork;
        _imageService = imageService;
        
    }
    public async Task<IResult> Handle(UploadBranchImageCommand request, CancellationToken cancellationToken)
    {
        //var uploadimagepath = await _imageService.UploadMultipleImagesAsync(request.Images);

        //var branchEO = await _unitOfWork.Branches.IncludeProps(branch => branch.Images).ToListAsync();

        //branchEO = uploadimagepath.Data;

        //await _unitOfWork.Branches.UpdateAsync(branchEO.Id, branchEO);
        //await _unitOfWork.SaveChangesAsync();
        return Result.Success(200);
    }
}
