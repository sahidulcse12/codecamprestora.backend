
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Exceptions;
using MediatR;

namespace CodeCampRestora.Application.Features.Branches.Commands.UpdateBranch;

public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand, BranchDTO>
{
    public readonly IUnitOfWork _unitOfWork;

    public UpdateBranchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BranchDTO> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
    {
        var branch = await _unitOfWork.Branches.GetByIdAsync(request.Id);
        if (branch == null)
        {
            throw new ResourceNotFoundException("Not Found the Brach");
        }


        branch.Name = request.Name;
        branch.IsAvailable = request.IsAvailable;
        branch.PriceRange = request.PriceRange;

        await _unitOfWork.Branches.UpdateAsync(branch.Id, branch);
        await _unitOfWork.SaveChangesAsync();



        return new BranchDTO
        {
            Name = branch.Name,
            IsAvailable = branch.IsAvailable,
            PriceRange = branch.PriceRange,
        };


    }
}
