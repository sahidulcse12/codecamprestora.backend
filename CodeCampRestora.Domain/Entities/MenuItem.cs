using CodeCampRestora.Domain.Entities.Common;
using CodeCampRestora.Infrastructure.Entities;

namespace CodeCampRestora.Domain.Entities
{
    public class MenuItem : AuditableEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public Guid ImageId { get; set; }
        public double Price { get; set; }
        public int? DisplayOrder { get; set; }
        public Guid CategoryId { get; set; }
        public MenuCategory Category { get; set; }
        public Guid RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }
    }
}