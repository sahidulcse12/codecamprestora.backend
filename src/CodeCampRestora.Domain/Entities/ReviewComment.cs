using CodeCampRestora.Domain.Entities.Common;

namespace CodeCampRestora.Domain.Entities;

public class ReviewComment : AuditableEntity<Guid>
{
    public Guid UserId { get; set; } = default!;
    //Foreign key ref
    public string CommentText { get; set; } = default!;
    public bool IsCommentHidden { get; set; } = false;
    public Guid ReviewId { get; set; }
    //Foreign key
    public Guid BranchId { get; set; }
    //Foreign key
}
