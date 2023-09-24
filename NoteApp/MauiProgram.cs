using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NoteApp.ViewModels;
using NoteApp.Views;
using NoteApp.DataBase;

namespace NoteApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		DataBaseContext context;
		context=new DataBaseContext();
        context.Database.EnsureCreated();
        var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddSingleton<NoteViewModel>();
        builder.Services.AddSingleton<NoteView>();
#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
