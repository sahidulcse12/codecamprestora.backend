namespace CodeCampRestora.Application.Models;

public record Error(string code, string Description)
{
    public static Error NotFound => new("not_found", "The request resource isn't found.");
}