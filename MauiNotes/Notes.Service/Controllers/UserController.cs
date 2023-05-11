using Auth0.ManagementApi.Models;
using Auth0.ManagementApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using Notes.Core.Models;

namespace Notes.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        private readonly string AUDIENCE = "<audience>";
        private readonly string CLIENT_ID = "<client_id>";
        private readonly string AUTH_URI = "<authorization_uri>";
        private readonly string USER_URI = "<user_uri>";
        private readonly string CLIENT_SECRET = "<client_secret>";

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUserInfo")]
        public async Task<UserInformation> Get()
        {
            var token = Request.Headers["Authorization"].First().Replace("Bearer ", "");

            var jwtToken = new JwtSecurityToken(token);

            var managementToken = await GetServiceToken();

            var client = new ManagementApiClient(managementToken, new Uri($"{USER_URI}/api/v2/"));

            var user = await client.Users.GetAsync(jwtToken.Payload["sub"].ToString());

            return JsonConvert.DeserializeObject<UserInformation>(user.UserMetadata.ToString().Replace("{{", "{").Replace("}}", "}"));
        }

        private async Task<string> GetServiceToken()
        {
            string returnValue = string.Empty;

            HttpResponseMessage response = null;
            var dict = new Dictionary<string, string>();
            dict.Add("grant_type", "client_credentials");
            dict.Add("audience", AUDIENCE);
            dict.Add("client_id", CLIENT_ID);
            dict.Add("client_secret", CLIENT_SECRET);

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
                    returnValue = authenticationInformation.access_token;
                }
            }
            else if (response != null)
            {
                await response.Content.ReadAsStringAsync();
            }


            return returnValue; 
        }

        private async Task<string> GetUserInfo(string token, string userId)
        {
                string returnValue = string.Empty;

                HttpResponseMessage response = null;

                using (HttpClient client = new HttpClient())
                {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                    response = await client.GetAsync($"{USER_URI}/api/v2/users/%7B{userId}%7D");
                }

                if (response != null &&
                    response.IsSuccessStatusCode)
                {
                    var authenticationInformation = JsonConvert.DeserializeObject<AuthenticationResponse>(await response.Content.ReadAsStringAsync());

                    if (authenticationInformation != null)
                    {
                        returnValue = authenticationInformation.access_token;
                    }
                }
                else if (response != null)
                {
                    await response.Content.ReadAsStringAsync();
                }


                return returnValue;
        }
    }
}