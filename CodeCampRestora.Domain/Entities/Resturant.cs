namespace CodeCampRestora.Domain.Entities;

public class Resturant
{
    public Guid Id { get; set; }
    public List<string>? CoverImage { get; set; } = new List<string>();
}
