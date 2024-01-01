using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Domain.Entities.Branchs;
using MediatR;
 

namespace CodeCampRestora.Application.Features.BranchS.Commands.Create_Branch;

public class  CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, BranchDto>
{
    public CreateBranchCommandHandler()
    {
        
    }
    public async Task<BranchDto> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
    {
        var branch = new Branch
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
