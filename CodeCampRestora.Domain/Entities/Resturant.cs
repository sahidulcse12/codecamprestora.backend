using CodeCampRestora.Domain.Entities.Branches;

namespace CodeCampRestora.Domain.Entities;

public class Resturant
{
    public Guid Id { get; set; }
    public List<string>? CoverImage { get; set; } = new List<string>();
    public List<Branch> Branches { get; set; }
}
