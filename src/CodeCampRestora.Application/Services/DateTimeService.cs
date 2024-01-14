using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.Services;

namespace CodeCampRestora.Application.Services;

[ScopedLifetime]
public class DateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.UtcNow;
}