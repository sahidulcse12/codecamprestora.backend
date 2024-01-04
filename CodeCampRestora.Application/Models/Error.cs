namespace CodeCampRestora.Application.Models;

public record Error(string code, string Description)
{
    public static Error NotFound => new("not_found", "The request resource isn't found.");
    public static Error NotValidated(string code, string description) => new($"{code}_validation_failed", description);
}