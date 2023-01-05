using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;
using ToDo.Viewmodel;

namespace Todo;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainViewModel>();

		builder.ConfigureSyncfusionCore();
#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
