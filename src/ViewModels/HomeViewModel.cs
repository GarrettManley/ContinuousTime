using System.Timers;
using ContinuousTime.Interfaces.Services;
using ContinuousTime.ViewModels.Base;

namespace ContinuousTime.ViewModels;

public class HomeViewModel : BaseViewModel
{
    private readonly ITimeService _timeService;

    public HomeViewModel(ITimeService timeService)
    {
        _timeService = timeService;
    }

    public string CurrentTime => _timeService.GetCurrentTimeString();

    public override async Task Initialize()
    {
        _timeService.ClockTimer.Elapsed += OnClockTick;

        await base.Initialize();
    }

    private void OnClockTick(object sender, ElapsedEventArgs e)
    {
        RaisePropertyChanged(() => CurrentTime);
    }
}