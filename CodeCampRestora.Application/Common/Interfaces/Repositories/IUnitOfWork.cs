using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.Common.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IBranchRepository Branches { get; }

        Task SaveChangesAsync();
    }
}
