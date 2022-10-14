using System.Globalization;
using System.Timers;
using ContinuousTime.Interfaces.Services;
using ContinuousTime.ViewModels.Base;

namespace ContinuousTime.ViewModels;

public class HomeViewModel : BaseViewModel
{
    private readonly ITimeService _timeService;
    private readonly ILocationService _locationService;

    public HomeViewModel(ITimeService timeService, ILocationService locationService)
    {
        _timeService = timeService;
        _locationService = locationService;
    }

    public string CurrentTime => _timeService.GetCurrentTimeString();

    public string CurrentContinuousTime { get; set; }

    public string CurrentLocation { get; set; }

    public override async Task Initialize()
    {
        _timeService.ClockTimer.Elapsed += OnClockTick;

        await base.Initialize();
    }

    public override void Dispose()
    {
        _timeService.ClockTimer.Elapsed -= OnClockTick;
    }

    private async void OnClockTick(object sender, ElapsedEventArgs e)
    {
        RaisePropertyChanged(() => CurrentTime);

        await UpdateCurrentLocation();
    }

    private async Task UpdateCurrentLocation()
    {
        var location = await _locationService.GetCurrentLocation();
        UpdateCurrentContinuousTime(location);
        CurrentLocation = location.Latitude.ToString(CultureInfo.InvariantCulture);

        RaisePropertyChanged(() => CurrentLocation);
    }

    private void UpdateCurrentContinuousTime(Location location)
    {
        CurrentContinuousTime = _timeService.GetCurrentContinuousTimeString(location);

        RaisePropertyChanged(() => CurrentContinuousTime);
    }
}