using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using FluentValidation.Results;
using System.Globalization;

namespace CodeCampRestora.Application.Common.Interfaces.Services;

[ScopedLifetime]
public class DateTimeService : IDateTimeService
{
    //private readonly IUnitOfWork _unitOfWork;

    //public DateTimeService(IUnitOfWork unitOfWork)
    //{
    //    _unitOfWork = unitOfWork;
    //}
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
