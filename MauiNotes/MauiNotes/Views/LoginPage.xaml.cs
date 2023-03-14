using MauiNotes.Interfaces;
using MauiNotes.Services;
using MauiNotes.ViewModels;

namespace MauiNotes.Views;

public partial class LoginPage : ContentPage
{
	private ILoginService _LoginService;

	public LoginPage(ILoginService loginService, LoginViewModel loginViewModel)
	{
		InitializeComponent();

        _LoginService = loginService;

		this.BindingContext = loginViewModel;
	}

}

