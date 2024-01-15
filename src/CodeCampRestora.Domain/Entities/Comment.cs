
using CodeCampRestora.Domain.Entities.Common;

namespace CodeCampRestora.Domain.Entities;

public class Comment : AuditableEntity<Guid>
{
    public string Name { get; set; } = default!;
    public string CommentBody { get; set; } = default!;
    public Guid BranchId { get; set; }
}
