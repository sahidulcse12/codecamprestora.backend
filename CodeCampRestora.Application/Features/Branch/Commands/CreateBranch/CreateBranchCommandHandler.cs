using CodeCampRestora.Application.DTOs;
using BranchEO = CodeCampRestora.Domain.Entities.Branchs.Branch;
using MediatR;
 

namespace CodeCampRestora.Application.Features.Branch.Commands.CreateBranch;

public class  CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, BranchDto>
{
    public CreateBranchCommandHandler()
    {
        
    }
    public async Task<BranchDto> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
    {
        var branch = new BranchEO
        {
            Name = request.Name,
            IsAvailable = request.IsAvailable,
        };
       // _repsitory.Add(branch);

        return new BranchDto
        {
            Name = branch.Name,
            IsAvailable = branch.IsAvailable,
        };
    }
}
