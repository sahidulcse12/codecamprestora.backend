using CodeCampRestora.Domain.Entities.UserRole;

namespace CodeCampRestora.Domain.Entities.SignUp
{
    public class RegisterUser
    {
        public required string Username { get; set; } = string.Empty;

        public required string Email { get; set; } = string.Empty;

        public required string Password { get; set; } = string.Empty;
        public required UserRoles RoleType { get; set; }
    }
}
