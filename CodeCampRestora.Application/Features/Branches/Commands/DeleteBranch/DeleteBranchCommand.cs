
using MediatR;

namespace CodeCampRestora.Application.Features.Branches.Commands.DeleteBranch;
public record DeleteBranchCommand : IRequest<string>
{
    
    public Guid Id { get; set; }

}
