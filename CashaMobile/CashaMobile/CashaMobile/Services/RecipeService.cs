using CashaMobile.Models;
using CashaMobile.Models.Enums;
using CashaMobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
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

        public async Task<ICollection<Recipe>> GetRecipesByFilter(RecipeFilter filter, string name = null)
        {
            ICollection<Recipe> filtered = null;

            switch (filter)
            {
                case RecipeFilter.IncludeAll:
                    filtered = await GetRecipes();
                    break;
                case RecipeFilter.IncludeExpired:
                    filtered = await GetRecipesByExpired();
                    break;
                case RecipeFilter.IncludeAllProductsInFridge:
                    filtered = await GetRecipesWithAllFridgeProduct();
                    break;
                case RecipeFilter.IncludeAnyProductInFrige:
                    filtered = await GetRecipesWithAnyFridgeProduct();
                    break;
            }

            if (name != null)
            {
                filtered = filtered.FindRecipeByName(name);
            }

            return filtered;
        }

        private async Task<ICollection<Recipe>> GetRecipes()
        {
            return await ParseRecipeResponse(await _httpClient.GetAsync("Recipe/All"));
        }

        private async Task<ICollection<Recipe>> GetRecipesByExpired()
        {
            string userId = App.Current.Properties["userId"].ToString();

            return await ParseRecipeResponse(await _httpClient.GetAsync($"Recipe/user/{userId}/product/expired"));
        }

        private async Task<ICollection<Recipe>> GetRecipesWithAnyFridgeProduct()
        {
            string userId = App.Current.Properties["userId"].ToString();
            
            return await ParseRecipeResponse(await _httpClient.GetAsync($"Recipe/user/{userId}/anyInFridge"));
        }

        private async Task<ICollection<Recipe>> GetRecipesWithAllFridgeProduct()
        {
            string userId = App.Current.Properties["userId"].ToString();

            return await ParseRecipeResponse(await _httpClient.GetAsync($"Recipe/user/{userId}/allInFridge"));
        }

        private async Task<ICollection<Recipe>> ParseRecipeResponse(HttpResponseMessage response)
        {
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    string stringResult = await response.Content.ReadAsStringAsync();

                    return JsonSerializer.Deserialize<List<Recipe>>(stringResult, _options);
                }
                else
                {
                    throw new Exception("Request error. Status code: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<Recipe>();
            
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