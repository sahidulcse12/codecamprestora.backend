using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CodeCampRestora.Domain.Entities.Common;
using CodeCampRestora.Infrastructure.Entities;

namespace CodeCampRestora.Domain.Entities
{
    public class MenuItemCategory : AuditableEntity<MenuItemCategory>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}