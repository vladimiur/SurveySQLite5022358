using Microsoft.Extensions.Logging;
using pruebni.Data;
using pruebni.Views;

namespace pruebni;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<SurveysView>();
        builder.Services.AddTransient<SurveyDetailsView>();

        builder.Services.AddSingleton<TodoItemDatabase>();

        return builder.Build();
        
	}
}
