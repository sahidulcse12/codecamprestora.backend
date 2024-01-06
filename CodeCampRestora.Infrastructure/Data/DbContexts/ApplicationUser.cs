using Microsoft.AspNetCore.Identity;
using CodeCampRestora.Domain.Entities.Authentication.Staff;

namespace CodeCampRestora.Infrastructure.Data.DbContexts
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public Guid StaffId { get; set; } = default!;
        public virtual Staff? Staff { get; set; }
    }
}
