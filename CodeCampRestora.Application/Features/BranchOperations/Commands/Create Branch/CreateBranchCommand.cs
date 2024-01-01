using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Domain.Entities.Branchs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.Features.BranchS.Commands.Create_Branch;

public record CreateBranchCommand : IRequest<BranchDto>
{
    public string Name { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }
    public PriceRange? PriceRange { get; set; }
}
