using Timer = System.Timers.Timer;

namespace ContinuousTime.Interfaces.Services;

public interface ITimeService
{
    public Timer ClockTimer { get; set; }
    public DateTimeOffset GetCurrentTime();
    public string GetCurrentTimeString();
}