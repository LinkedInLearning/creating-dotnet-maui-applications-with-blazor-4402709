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
        private static string _token = string.Empty;

        private readonly IPlatformHelper _platformHelper;
        private readonly IKeyValueStorageService _localStore;

        private readonly string AUDIENCE = "https://MauiBlazor.org";
        private readonly string CLIENT_ID = "<token>";
        private readonly string AUTH_URI = "<endpoint>";
        private readonly string OFFLINE_EXPIRATION = "OfflineExpiration";




        public LoginService(IKeyValueStorageService localStore,
            IPlatformHelper platformHelper)
        {
            _localStore = localStore;
            _platformHelper = platformHelper;
        }

        public Task<bool> IsAuthenticated()
        {
            return true;
        }

        public Task<bool> Login(string username, string password)
        {
            return true;
        }

        private async Task Logout()
        {
            _token = string.Empty;
            await _localStore.RemoveValue(OFFLINE_EXPIRATION);
        }

        public string CurrentToken()
        {
            return _token;
        }
    }
}