using MauiNotes.Interfaces;

namespace MauiNotes.Views;

public partial class BlazorContainerPage : ContentPage
{
    private ILoginService _loginService;
	public BlazorContainerPage(ILoginService loginService)
	{
		InitializeComponent();

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