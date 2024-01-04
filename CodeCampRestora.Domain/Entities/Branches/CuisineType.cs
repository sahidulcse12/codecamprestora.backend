namespace CodeCampRestora.Domain.Entities.Branches;


public class CuisineType 
{
    public Guid Id { get; set; }
    public required string CuisineTag { get; set; }
    public Guid BranchId { get; set; }
    public  Branch Branch { get; set; }

}
