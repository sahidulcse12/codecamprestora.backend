using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.Features.Branch.Commands.Create_Branch;

public record CreateBranchCommand(string name) : IRequest;
