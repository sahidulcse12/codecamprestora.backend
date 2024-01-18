using System.Globalization;
using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.Services;

namespace CodeCampRestora.Application.Services;

[ScopedLifetime]
public class DateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.UtcNow;

    public TimeOnly ConvertToTimeOnly(string timeString)
    {
        if (TimeOnly.TryParseExact(
            timeString,
            "h:mm tt",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out TimeOnly timeOnly))
        {
            var today = DateTime.Today;
            today += timeOnly.ToTimeSpan();
            var todayAsUTC = today.ToUniversalTime();

            return TimeOnly.FromDateTime(todayAsUTC);
        }
        else
        {
            throw new ArgumentException("Invalid time format", nameof(timeString));
        }
    }
}
