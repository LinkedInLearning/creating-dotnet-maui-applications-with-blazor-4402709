using Notes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasmNotes.Services
{
    internal class LoginService : ILoginService
    {
        private bool _isAuthenticated = false;

        public bool IsAuthenticated => _isAuthenticated;

        public bool Login(string username, string password)
        {
            _isAuthenticated = true;

            return _isAuthenticated;
        }
    }
}