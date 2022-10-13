using ContinuousTime.Interfaces;
using ContinuousTime.Pages;

namespace ContinuousTime.Services;

public class NavigationService : INavigationService
{
    public Task InitializeAsync()
    {
        return NavigateToAsync(nameof(HomePage));
    }

    public Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null)
    {
        return routeParameters != null
            ? Shell.Current.GoToAsync(route, routeParameters)
            : Shell.Current.GoToAsync(route);
    }

    public Task CloseAsync()
    {
        throw new NotImplementedException();
    }
}