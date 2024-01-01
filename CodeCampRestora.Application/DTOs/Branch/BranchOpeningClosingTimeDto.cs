 
namespace CodeCampRestora.Application.DTOs.BranchDTO_s;

public class BranchOpeningClosingTimeDto
{
    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly Opening { get; set; }
    public TimeOnly Closing { get; set; }
    public bool IsClosed { get; set; }
}
