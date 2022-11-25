using CashaMobile.Services.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CashaMobile.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;
        private readonly CookieContainer _cookieJar;
        private readonly Uri _uri;

        public AccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _cookieJar = new CookieContainer();
            _uri = _httpClient.BaseAddress;
        }

        public async Task<bool> LoginAsync(string login, string password)
        {
            var client = SetUpHttp();

            HttpResponseMessage response = await client.PostAsync("Account/login",
                new StringContent(JsonSerializer.Serialize(new { Login = login, Password = password }),
                    Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            var responseCookies = _cookieJar.GetCookies(_uri);
            foreach (Cookie cookie in responseCookies)
            {
                string cookieName = cookie.Name;
                string cookieValue = cookie.Value;

                App.Current.Properties[cookieName] = cookieValue;
            }

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(App.Current.Properties["loggedToken"].ToString());


            foreach (Claim claim in jwtSecurityToken.Claims)
            {
                if (claim.Type == "Id")
                {
                    App.Current.Properties["userId"] = claim.Value;
                    break;
                } 
            }

            return response.StatusCode == HttpStatusCode.OK;
        }

        public async Task<bool> RegiterAsync(string login, string password, string passwordConfirm)
        {
            var cookieJar = new CookieContainer();
            var client = SetUpHttp();

            HttpResponseMessage response = await client.PostAsync("Account/register",
                new StringContent(JsonSerializer.Serialize(
                    new 
                    { 
                        Login = login,
                        Password = password,
                        PasswordConfirm = passwordConfirm
                    }),
                    Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            return response.StatusCode == HttpStatusCode.OK;
        }

        private HttpClient SetUpHttp()
        {
            Uri address = _httpClient.BaseAddress;

            var handler = new HttpClientHandler
            {
                CookieContainer = _cookieJar,
                UseCookies = true,
                UseDefaultCredentials = false
            };

            var client = new HttpClient(handler)
            {
                BaseAddress = address,
            };

            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;
        }
    }
}
