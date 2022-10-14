using ContinuousTime.Interfaces.Services;
using Timer = System.Timers.Timer;

namespace ContinuousTime.Services;

public class TimeService : ITimeService
{
    private static int _timerInterval;

    public TimeService(int timerInterval)
    {
        _timerInterval = timerInterval;
        StartTimer();
    }

    public Timer ClockTimer { get; set; }

    public DateTimeOffset GetCurrentTime()
    {
        return DateTimeOffset.UtcNow;
    }

    public string GetCurrentTimeString()
    {
        return GetCurrentTime()
            .UtcDateTime.ToLongTimeString();
    }

    private void StartTimer()
    {
        ClockTimer = new Timer(_timerInterval)
        {
            AutoReset = true,
            Enabled = true
        };
    }
}