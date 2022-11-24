using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CashaMobile.Models;
using CashaMobile.Services.Interfaces;

namespace CashaMobile.Services
{
    public class UserProductService : IUserProductService
    {
        private readonly HttpClient _httpClient;
        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public UserProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            
        }

        public async Task AddUserProduct(UserProduct userProduct)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteUserProduct(int userProductId)
        {
            throw new NotImplementedException();
        }

        public async Task<UserProduct> GetUserProductByID(int userProductId)
        {
            HttpResponseMessage requestResult = await _httpClient.GetAsync($"UserProduct/{userProductId}");

            if (requestResult.IsSuccessStatusCode)
            {
                string stringResult = await requestResult.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<UserProduct>(stringResult, options);

            }
            else
            {
                throw new Exception("Request error. Status code: " + requestResult.StatusCode);
            }
        }

        public async Task<List<UserProduct>> GetUserProductsByUserId(string userId)
        {
            HttpResponseMessage requestResult = await _httpClient.GetAsync($"UserProduct/User/{userId}");

            if (requestResult.IsSuccessStatusCode)
            {
                string stringResult = await requestResult.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<List<UserProduct>>(stringResult, options);

            }
            else
            {
                throw new Exception("Request error. Status code: " + requestResult.StatusCode);
            }
        }

        public async Task UpdateUserProduct(UserProduct userProduct)
        {
            throw new NotImplementedException();
        }
    }
}
