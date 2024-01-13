using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Infrastructure.Data.Repositories
{

    [ScopedLifetime]
    public class ReviewRepository : Repository<Review, Guid>,IReviewRepository
    {
        public ReviewRepository(IApplicationDbContext applicationDbContext)
            : base((DbContext)applicationDbContext)
        {
        }
    }
}
