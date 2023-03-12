using MauiNotes.Interfaces;
using MauiNotes.Models;

namespace MauiNotes.Views;

public partial class BlazorContainerPage : ContentPage
{
    private ILoginService _loginService;
	public BlazorContainerPage(ILoginService loginService)
	{
		InitializeComponent();

        rootComponent.Parameters = new Dictionary<string, object>
        {
            { "InitialRoute", $"/NotesList/{NoteType.Business}" }
        };
        _loginService = loginService;
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        if (_loginService.IsAuthenticated == false) 
        {
            await Shell.Current.GoToAsync("login", true);
        }
    }
}