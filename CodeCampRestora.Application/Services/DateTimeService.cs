using CodeCampRestora.Application.Attributes;
using System.Globalization;

namespace CodeCampRestora.Application.Common.Interfaces.Services;

[ScopedLifetime]
public class DateTimeService
{
    public TimeOnly ConvertToTimeOnly(string timeString)
    {
        if (TimeOnly.TryParseExact(
            timeString,
            "h:mm tt",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out TimeOnly timeOnly))
        {
            return timeOnly;
        }
        else
        {
            throw new ArgumentException("Invalid time format", nameof(timeString));
        }
    }
}
