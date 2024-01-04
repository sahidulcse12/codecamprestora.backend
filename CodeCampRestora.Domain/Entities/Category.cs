using CodeCampRestora.Domain.Entities.Common;

namespace CodeCampRestora.Infrastructure.Entities;

public class Category : AuditableEntity<Category>
{
    public Guid Id { get; set; } = default!;
    public string Name { get; set; } = default!;
}
