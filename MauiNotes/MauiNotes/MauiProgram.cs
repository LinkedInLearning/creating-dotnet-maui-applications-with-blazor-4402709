using Microsoft.Extensions.Logging;
using MauiNotes.Views;
using MauiNotes.Services;
using MauiNotes.Interfaces;
using MauiNotes.ViewModels;

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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddMauiBlazorWebView();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif 

        RegisterDependencyInjection(builder);

        RegisterRoutes();

        return builder.Build();
    }

    private static void RegisterRoutes()
    {
        Routing.RegisterRoute("login", typeof(LoginPage));
    }

    private static void RegisterDependencyInjection(MauiAppBuilder builder)
    {
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<BlazorContainerPage>();

        builder.Services.AddTransient<LoginViewModel>();

        builder.Services.AddSingleton<ILoginService, LoginService>();
        builder.Services.AddSingleton<INotesService, NotesService>();
        builder.Services.AddSingleton<INoteReader, NoteReader>();
    }
}
