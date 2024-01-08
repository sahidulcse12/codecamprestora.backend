
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.Exceptions;
using MediatR;

namespace CodeCampRestora.Application.Features.Branches.Commands.DeleteBranch;

public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand, string>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBranchCommandHandler(IUnitOfWork unitOfWork)
    {
         _unitOfWork = unitOfWork;
    }
    public async Task<string> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
    {
        var branch = await _unitOfWork.Branches.GetByIdAsync(request.Id);
        if (branch == null)
        {
            throw new ResourceNotFoundException("Branch Not Found");
        }
        await _unitOfWork.Branches.DeleteAsync(branch.Id);
        await _unitOfWork.SaveChangesAsync();
        
        return "Deleted Sucessufully";
    }
}
 