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

        public async Task<bool> IsAuthenticated()
        {
            return await HasValidCredentials();
        }

        public async Task<bool> Login(string username, string password)
        {
            bool loginSuccess = false;
            if (await _platformHelper.IsOnline())
            {
                HttpResponseMessage response = null;
                var dict = new Dictionary<string, string>();
                dict.Add("grant_type", "password");
                dict.Add("username", username);
                dict.Add("password", password);
                dict.Add("audience", AUDIENCE);
                dict.Add("client_id", CLIENT_ID);

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                    response = await client.PostAsync(AUTH_URI, new FormUrlEncodedContent(dict));
                }

                if (response != null &&
                    response.IsSuccessStatusCode)
                {
                    var authenticationInformation = JsonConvert.DeserializeObject<AuthenticationResponse>(await response.Content.ReadAsStringAsync());
                    
                    if (authenticationInformation != null)
                    {
                        var expiresTime = DateTime.Now.AddDays(3);
                        await _localStore.SetValue<DateTime>(OFFLINE_EXPIRATION, expiresTime);
                        _token = authenticationInformation.access_token;
                        loginSuccess = true;
                    }
                }
            }
            if (loginSuccess == false)
            {
                await Logout();
            }
            return loginSuccess;
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

        private async Task<bool> HasValidCredentials()
        {
            bool returnValue = false;
            try
            {
                var offlineExpiration = await _localStore.GetValue<DateTime?>(OFFLINE_EXPIRATION);
                var isOnline = await _platformHelper.IsOnline();
                if (string.IsNullOrEmpty(_token) == false)
                {
                    var jwtToken = new JwtSecurityToken(_token);
                    returnValue = jwtToken != null && jwtToken.ValidFrom <= DateTime.UtcNow && jwtToken.ValidTo >= DateTime.UtcNow;
                }
                if (returnValue == false && isOnline == false &&
                    offlineExpiration != null && offlineExpiration.HasValue)
                {
                    returnValue = offlineExpiration.Value >= DateTime.UtcNow;
                }
            }
            catch (Exception) { }
            return returnValue;
        }
    }
}