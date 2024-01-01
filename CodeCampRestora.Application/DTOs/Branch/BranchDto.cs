using CodeCampRestora.Domain.Entities.Branchs;

namespace CodeCampRestora.Application.DTOs;

public class BranchDto
{
    public string Name { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }
    public PriceRange? PriceRange { get; set; }
}
