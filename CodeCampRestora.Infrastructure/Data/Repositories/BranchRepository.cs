using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Domain.Entities.Branches;
using CodeCampRestora.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CodeCampRestora.Infrastructure.Data.Repositories;

public class BranchRepository : GenericRepository<Branch, Guid>
{
    public BranchRepository(ApplicationDbContext applicationDbContext)
        : base((DbContext)applicationDbContext)
    {
        
    }
    
}
