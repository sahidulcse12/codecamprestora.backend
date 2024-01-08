using CodeCampRestora.Domain.Entities.Authentication.UserRole;

namespace CodeCampRestora.Application.DTOs;

public class RegisterUserDTO
{
        public required string FirstName { get; set; } = default!;

        public required string LastName { get; set; } = default!;

        public required string Email { get; set; } = default!;
        public required string Password { get; set; } = default!;
        public required UserRoles RoleType { get; set; }
}