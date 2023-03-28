using WasmNotes.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Notes.Core.Interfaces;
using WasmNotes;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

RegisterDependencyInjection(builder);

await builder.Build().RunAsync();

static void RegisterDependencyInjection(WebAssemblyHostBuilder builder)
{
    builder.Services.AddSingleton<ILoginService, LoginService>();
    builder.Services.AddSingleton<INotesService, NotesService>();
    builder.Services.AddTransient<IGlobalNavigation, GlobalNavigation>();
    builder.Services.AddTransient<INoteReader, NoteReader>();
}