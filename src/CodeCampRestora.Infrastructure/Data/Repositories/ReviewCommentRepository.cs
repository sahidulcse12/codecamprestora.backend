using Microsoft.EntityFrameworkCore;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;
using CodeCampRestora.Application.Common.Interfaces.Repositories;

namespace CodeCampRestora.Infrastructure.Data.Repositories;

[ScopedLifetime]
public class ReviewCommentRepository : Repository<Comment, Guid>, IReviewCommentRepository
{
    public ReviewCommentRepository(IApplicationDbContext applicationDbContext) 
        : base((DbContext)applicationDbContext)
    {
        
    }
}
