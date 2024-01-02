namespace CodeCampRestora.Domain.Entities;

public class Image
{
    public Guid Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Type { get; set; } = default!;
    public string DataAsBase64 {get; set;} = default!;
    public int SizeInBytes;
}