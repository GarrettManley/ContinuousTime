using ContinuousTime.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace ContinuousTime.Services;

public class LocationService : ILocationService
{
    private bool _isCheckingLocation;
    private Logger<LocationService> _logger = new(new LoggerFactory());

    public async Task<Location> GetCurrentLocation()
    {
        var request = new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromSeconds(10));

        var location = await Geolocation.GetLocationAsync(request, default);

        _logger.Log(LogLevel.Debug, $"Location Resolved: {location.Longitude}");

        return location;
    }
}