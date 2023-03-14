using MauiNotes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiNotes.ViewModels
{
    public class LoginViewModel: BaseViewModel
    {
        private ILoginService _LoginService;

        public LoginViewModel(ILoginService loginService)
        {
            _LoginService = loginService;
        }

        private Command _LoginCommand;

        public Command Login
        {
            get { return _LoginCommand?? new Command(async () => await ExecuteLogin()); }
        }

        private async Task ExecuteLogin()
        {
            _LoginService.Login("", "");
        }
    }
}
