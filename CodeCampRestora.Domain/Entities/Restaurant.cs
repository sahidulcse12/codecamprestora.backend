using CodeCampRestora.Domain.Entities.Common;

namespace CodeCampRestora.Infrastructure.Entities;

public class Restaurant : AuditableEntity<Restaurant>
{
    public Guid Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public Guid ImageId { get; set; } = default!;

    public int CategoryId { get; set; }
    public List<Category>? Categories { get; set; }
}
