using CodeCampRestora.Domain.Identity;
using CodeCampRestora.Domain.Entities.Common;
using CodeCampRestora.Domain.Entities.Branches;

namespace CodeCampRestora.Infrastructure.Entities;

public class Restaurant : AuditableEntity<Guid>
{
    public string Name { get; set; } = default!;
    public Guid ImageId { get; set; } = default!;
    public ApplicationUser? ApplicationUser { get; set; }
    public IList<Branch>? Branches { get; set; }
    public int CategoryId { get; set; }
    public ICollection<Category>? Categories { get; set; }
}
