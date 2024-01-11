namespace CodeCampRestora.Application.DTOs
{
    public class MenuItemDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }
        public int? DisplayOrder { get; set; }
        public Guid ImageId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BranchId { get; set; }
    }
}