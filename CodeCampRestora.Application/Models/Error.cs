namespace CodeCampRestora.Application.Models;

public record Error(string code, string Description)
{
    public static Error NotFound(string description) => new("not_found", description);
    public static Error NotValidated(string code, string description) => new($"{code}_validation_failed", description);
}

public record AuthErrors
{
    public static Error UserExists => new("User.Exists", "User already exists.");
    public static Error RoleNotFound => new("User.RoleNotFound", "Role doesn't exist.");
    public static Error UserCreationFailed => new("User.CreationFailed", "User creation failed.");
    public static Error LoginError => new("User.LoginError", "Login failed.");
    public static Error UserNotFound => new("User.NotFound", "User not found.");
}