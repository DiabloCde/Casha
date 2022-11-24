using CashaMobile.Services;
using CashaMobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CashaMobile.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;

        public AccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> LoginAsync(string login, string password)
        {
            Uri address = _httpClient.BaseAddress;
            
            var cookieJar = new CookieContainer();
            var handler = new HttpClientHandler
            {
                CookieContainer = cookieJar,
                UseCookies = true,
                UseDefaultCredentials = false

            };

            var client = new HttpClient(handler)
            {
                BaseAddress = address,
            };
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage response = await client.PostAsync("Account/login",
                new StringContent(JsonSerializer.Serialize(new { Login = login, Password = password }),
                    Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            var responseCookies = cookieJar.GetCookies(address);
            foreach (Cookie cookie in responseCookies)
            {
                string cookieName = cookie.Name;
                string cookieValue = cookie.Value;

                App.Current.Properties[cookieName] = cookieValue;
            }

            return response.StatusCode == HttpStatusCode.OK;
        }
    }
}
