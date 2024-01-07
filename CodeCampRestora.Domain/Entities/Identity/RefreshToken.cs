using CodeCampRestora.Domain.Entities.Common;

namespace CodeCampRestora.Domain.Identity;

public class RefreshToken : BaseEntity<Guid>
{
    public Guid JwtId { get; init; }
    public Guid ApplicationUserId { get; set; }
    public ApplicationUser User { get; set; } = default!;
    public DateTime Expiry { get; set; } = default!;
    public bool Used { get; set; }
}