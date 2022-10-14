using ContinuousTime.Interfaces;
using ContinuousTime.Interfaces.Services;

namespace ContinuousTime;

public partial class App : Application
{
	public App(INavigationService navigationService)
	{
		InitializeComponent();
		
		MainPage = new AppShell(navigationService);
	}
}
