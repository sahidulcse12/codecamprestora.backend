
namespace CodeCampRestora.Domain.Entities;

public class Comment
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string CommentBody { get; set; }
    public Guid BranchId { get; set; }
}
