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

    /// <summary>
    /// loc_time=UTC+(24/360)*loc_deg_long
    /// </summary>
    /// <returns></returns>
    public DateTimeOffset GetCurrentContinuousTime(Location location)
    {
        const double k = 24d / 360d;
        var hours = k * location.Longitude;
        var minutes = hours * 60;
        var seconds = minutes * 60;
        return GetCurrentTime()
            .AddSeconds(seconds);
    }

    public string GetCurrentContinuousTimeString(Location location)
    {
        return GetCurrentContinuousTime(location)
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