using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Newtonsoft.Json;
using Notes.Core.Interfaces;
using Notes.Core.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;

namespace Notes.Core.Services
{
    public class LoginService : ILoginService
    {
        private bool _isAuthenticated = false;

        public LoginService()
        {
        }

        public Task<bool> IsAuthenticated()
        {
            var tcs = new TaskCompletionSource<bool>();
            tcs.SetResult(_isAuthenticated);
            return tcs.Task;
        }

        public Task<bool> Login(string username, string password)
        {
            var tcs = new TaskCompletionSource<bool>();
            _isAuthenticated = true;
            tcs.SetResult(_isAuthenticated);

            return tcs.Task;
        }

        private Task Logout()
        {
            _isAuthenticated = false;
            return Task.CompletedTask;
        }
    }
}