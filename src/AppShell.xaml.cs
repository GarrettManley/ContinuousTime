using ContinuousTime.Interfaces;
using ContinuousTime.Pages;

namespace ContinuousTime;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
    }
}