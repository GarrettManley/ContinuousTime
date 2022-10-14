using ContinuousTime.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace ContinuousTime.Services;

public class LocationService : ILocationService
{
    private bool _isCheckingLocation;
    private Location _locationCache;

    /// <summary>
    /// Async request to update the cached Location value from the user's device GPS data.
    /// </summary>
    /// <returns>Device's Current <see cref="Location"/> or null if there is a pending request already on progress</returns>
    public async Task<Location> GetCurrentLocation()
    {
        if (_isCheckingLocation)
        {
            return _locationCache;
        }

        var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(10));

        try
        {
            _isCheckingLocation = true;
            _locationCache = await Geolocation.GetLocationAsync(request, default);
        }
        finally
        {
            _isCheckingLocation = false;
        }

        return _locationCache;
    }
}