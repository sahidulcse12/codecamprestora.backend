

namespace CodeCampRestora.Application.Common.Interfaces.Services;

internal interface IDateTimeService
{
    public TimeOnly ConvertToTimeOnly(string timeString);
}
