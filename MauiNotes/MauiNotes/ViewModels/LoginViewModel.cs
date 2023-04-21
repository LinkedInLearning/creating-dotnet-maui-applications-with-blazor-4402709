using Notes.Core.Interfaces;

namespace MauiNotes.ViewModels
{
    public class LoginViewModel: BaseViewModel
    {
        private ILoginService _LoginService;
        private IGlobalNavigation _GlobalNavigation;

        public LoginViewModel(ILoginService loginService,
            IGlobalNavigation globalNavigation)
        {
            _LoginService = loginService;
            _GlobalNavigation = globalNavigation;
        }

        private Command _LoginCommand;

        private string _userName = "";
        public string UserName {
            get
            {
                return _userName;
            }
            set
            {
                if (_userName != value) 
                {
                    _userName = value;
                    NotifyPropertyChanged(nameof(UserName));
                }
            }
        }

        private string _password = "";
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    NotifyPropertyChanged(nameof(Password));
                }
            }
        }

        public Command Login
        {
            get { return _LoginCommand?? new Command(async () => await ExecuteLogin()); }
        }

        private async Task ExecuteLogin()
        {
            if (await _LoginService.Login(UserName, Password) == true)
            {
                await _GlobalNavigation.NavigateBack();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Authorization Error", "Unable to Login.", "OK");
            }
        }
    }
}
