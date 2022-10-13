using ContinuousTime.Interfaces.Services;

namespace ContinuousTime.Services;

public class TimeService : ITimeService
{
    public DateTimeOffset GetCurrentTime()
    {
        return DateTimeOffset.UtcNow;
    }
}