using Microsoft.Extensions.Logging;
using MauiNotes.Services;
using MauiNotes.Interfaces;
using MauiNotes.ViewModels;
using MauiNotes.Views;

namespace MauiNotes;

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
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif
		RegisterDependencyInjection(builder);

		return builder.Build();
	}

    private static void RegisterDependencyInjection(MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<ILoginService, LoginService>();
        builder.Services.AddSingleton<INotesService, NotesService>();
        builder.Services.AddSingleton<INoteReader, NoteReader>();
        builder.Services.AddSingleton<List<GlobalNavigation.ApplicationRoute>>(GetNativeApplicationRoutes());
        builder.Services.AddTransient<IGlobalNavigation, GlobalNavigation>();

        builder.Services.AddTransient<LoginViewModel>();

		builder.Services.AddTransient<LoginPage>();
    }

    private static List<GlobalNavigation.ApplicationRoute> GetNativeApplicationRoutes()
    {
        return new List<GlobalNavigation.ApplicationRoute>
        {
            new GlobalNavigation.ApplicationRoute
            {
                Uri = "/Login",
                Type = GlobalNavigation.ApplicationRoute.NavigationType.NativeModal,
                NativeType = typeof(LoginPage)
            },
        };
    }
}
