namespace ContinuousTime.Interfaces.Services;

public interface ILocationService
{
    public Task<Location> GetCurrentLocation();
}