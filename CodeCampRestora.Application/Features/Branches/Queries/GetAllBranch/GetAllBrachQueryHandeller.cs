

using CodeCampRestora.Application.DTOs;
using MediatR;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.Branches.Queries.GetAllBranch;

public class GetAllBrachQueryHandeller : IQueryHandler<GetAllBranchesQuery, IResult<BranchDTO>>
{
    private readonly IUnitOfWork _uniOfWork; 
    public GetAllBrachQueryHandeller(IUnitOfWork uniOfWork)
    {
         _uniOfWork = uniOfWork;
    }

    public async Task<IResult<BranchDTO>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
    {
         
        throw(new NotImplementedException());   
    }
}
