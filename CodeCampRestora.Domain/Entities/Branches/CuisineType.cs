namespace CodeCampRestora.Domain.Entities.Branches;


public class CuisineType 
{
    public required string CuisineTag { get; set; }
    public Branch Branch { get; set; }

}
