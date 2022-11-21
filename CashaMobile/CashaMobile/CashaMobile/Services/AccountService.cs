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
            var response = await _httpClient.PostAsync("Account/login",
                new StringContent(JsonSerializer.Serialize(new { Login = login, Password = password }),
                    Encoding.UTF8,
                    "application/json"));

            return response.StatusCode == HttpStatusCode.OK;
        }
    }
}
