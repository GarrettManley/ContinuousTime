using ContinuousTime.Interfaces;
using ContinuousTime.Interfaces.Services;
using ContinuousTime.Services;

namespace ContinuousTime;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.RegisterServices()
			.RegisterViewModels()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}

	private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
	{
		builder.Services.AddSingleton<INavigationService, NavigationService>();
		builder.Services.AddSingleton<ITimeService, TimeService>();
		
		return builder;
	}

	private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
	{

		return builder;
	}
}
