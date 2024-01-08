namespace CodeCampRestora.Application.Models;

public record Error(string code, string Description)
{
    public static Error NotFound(string description) => new("not_found", description);
    public static Error NotValidated(string code, string description) => new($"{code}_validation_failed", description);
}