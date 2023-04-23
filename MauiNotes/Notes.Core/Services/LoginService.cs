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
        private static string _token = "";
        private readonly IPlatformHelper _platformHelper;
        private readonly IKeyValueStorageService _localStore;

        private readonly string AUDIENCE = "https://MauiBlazor.org";
        private readonly string CLIENT_ID = "btxhnjTeMdQfJbWvUVmZzvfGhctICq5r";
        private readonly string AUTH_URI = "https://bowman74.auth0.com/oauth/token";

        private readonly string OFFLINE_EXPIRATION = "OfflineExpiration";

        public LoginService(IKeyValueStorageService localStore,
                    IPlatformHelper platformHelper)
        {
            _localStore = localStore;
            _platformHelper = platformHelper;
        }

        public Task<bool> IsAuthenticated()
        {
            var tcs = new TaskCompletionSource<bool>();
            tcs.SetResult(true);
            return tcs.Task;
        }

        public Task<bool> Login(string username, string password)
        {
            var tcs = new TaskCompletionSource<bool>();
            tcs.SetResult(true);

            return tcs.Task;
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