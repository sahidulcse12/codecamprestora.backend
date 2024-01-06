using Microsoft.AspNetCore.Identity;

namespace CodeCampRestora.Domain.Entities.Authentication.Staff
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public Guid StaffId { get; set; } = default!;
        public virtual Staff? Staff { get; set; }
    }
}