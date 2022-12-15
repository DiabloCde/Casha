using CashaMobile.Models;
using CashaMobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CashaMobile.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly HttpClient _httpClient;
        private JsonSerializerOptions _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public RecipeService(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        public async Task<Recipe> GetRecipeByID(int recipeId)
        {
            try
            {
                HttpResponseMessage requestResult = await _httpClient.GetAsync($"Recipe/{recipeId}");

                if (requestResult.IsSuccessStatusCode)
                {
                    string stringResult = await requestResult.Content.ReadAsStringAsync();

                    return JsonSerializer.Deserialize<Recipe>(stringResult, _options);

                }
                else
                {
                    throw new Exception("Request error. Status code: " + requestResult.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<Recipe>> GetRecipesByProductd(string userId = "23d581c7-f64d-4308-a5ce-80584a081347", int productId = 3)
        {
            List<Recipe> recipes = new List<Recipe>();

            try
            {
                HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"Recipe/user/{userId}/product/expired/{productId}");

                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    throw new Exception("Request error. Status code: " + httpResponseMessage.StatusCode);
                }

                string stringResult = await httpResponseMessage.Content.ReadAsStringAsync();
                recipes = JsonSerializer.Deserialize<List<Recipe>>(stringResult, _options);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return recipes;
        }
    }
}
