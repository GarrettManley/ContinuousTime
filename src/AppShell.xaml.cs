using ContinuousTime.Interfaces;
using ContinuousTime.Pages;

namespace ContinuousTime;

public partial class AppShell : Shell
{
    private readonly INavigationService _navigationService;
    public AppShell(INavigationService navigationService)
    {
        _navigationService = navigationService;
        
        InitializeComponent();

        RegisterRoutes();
    }

    private static void RegisterRoutes()
    {
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
    }

    protected override async void OnParentSet()
    {
        base.OnParentSet();
        
        await _navigationService.InitializeAsync();
    }
}