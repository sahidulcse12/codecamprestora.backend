 
using CodeCampRestora.Domain.Entities.Common;

namespace CodeCampRestora.Domain.Entities.Branches;
 
public class OpeningClosingTime:AuditableEntity<Guid>
{
    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly Opening { get; set; }
    public TimeOnly Closing { get; set; }
    public bool IsClosed { get; set; }
    public Guid BranchId { get; set; }
    
}
