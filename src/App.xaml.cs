using ContinuousTime.Interfaces;

namespace ContinuousTime;

public partial class App : Application
{
	public App(INavigationService navigationService)
	{
		InitializeComponent();
		
		MainPage = new AppShell(navigationService);
	}
}
