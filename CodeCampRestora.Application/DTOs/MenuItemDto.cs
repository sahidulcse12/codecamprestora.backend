namespace CodeCampRestora.Application.DTOs
{
    public class MenuItemDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }
        public int? DisplayOrder { get; set; }
        public int CategoryId { get; set; }
        public int BranchId { get; set; }
    }
}