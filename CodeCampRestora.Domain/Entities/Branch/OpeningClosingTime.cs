using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Domain.Entities.Branch;

public class OpeningClosingTime : BaseEntity
{
    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly Opening { get; set; }
    public TimeOnly Closing { get; set; }
<<<<<<< HEAD
    public bool IsClosed { get; set; }
=======
>>>>>>> 5ae0055 (feat : branc entities completed)
}
