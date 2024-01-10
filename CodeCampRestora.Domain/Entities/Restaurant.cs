using CodeCampRestora.Domain.Entities.Common;
using CodeCampRestora.Domain.Identity;

namespace CodeCampRestora.Infrastructure.Entities;

public class Restaurant : AuditableEntity<Guid>
{
    public string Name { get; set; } = default!;
    public Guid ImageId { get; set; } = default!;
    public int CategoryId { get; set; }
    public List<Category>? Categories { get; set; }
    public ApplicationUser? ApplicationUser { get; set; }
}
