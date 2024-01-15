using CodeCampRestora.Domain.Enums;
using CodeCampRestora.Domain.Entities.Common;

namespace CodeCampRestora.Domain.Entities.Branches;

public class Branch : AuditableEntity<Guid>
{
    public string Name { get; set; } = string.Empty;
    public PriceRange? PriceRange { get; set; }
    public ICollection<OpeningClosingTime>? OpeningClosingTimes { get; set; }
    public ICollection<CuisineType>? CuisineTypes { get; set; }
    public bool IsAvailable { get; set; }
    public Guid RestaurantId { get; set; }
    public Address? Address { get; set; }

}