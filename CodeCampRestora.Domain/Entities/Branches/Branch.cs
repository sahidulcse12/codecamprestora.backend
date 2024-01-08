using CodeCampRestora.Domain.Enums;

namespace CodeCampRestora.Domain.Entities.Branches;

public class Branch
{
    public Branch()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }
    // Relationship 
    public Guid AddressId { get; set; }

    public  Address? Address { get; set; }
    public PriceRange? PriceRange { get; set; }

    public IList<OpeningClosingTime> OpeningClosingTimes { get; set; }
     //public Resturant Resturant { get; set; } = new Resturant();
    public IList<CuisineType> CuisineTypes { get; set; }
}
