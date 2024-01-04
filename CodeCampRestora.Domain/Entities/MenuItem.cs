using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CodeCampRestora.Infrastructure.Entities;

namespace CodeCampRestora.Domain.Entities
{
    public class MenuItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public int? DisplayOrder { get; set; }
        public int CategoryId { get; set; }
        public MenuItemCategory Category { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}