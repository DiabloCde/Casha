﻿using CashaMobile.Models;
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
                    filtered = await GetRecipes();
                    break;
                case RecipeFilter.IncludeAnyProductInFrige:
                    filtered = await GetRecipes();
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
            try
            {
                HttpResponseMessage requestResult = await _httpClient.GetAsync("Recipe/All");

                if (requestResult.IsSuccessStatusCode)
                {
                    string stringResult = await requestResult.Content.ReadAsStringAsync();

                    return JsonSerializer.Deserialize<List<Recipe>>(stringResult, _options);
                }
                else
                {
                    throw new Exception("Request error. Status code: " + requestResult.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<Recipe>();
        }

        private async Task<ICollection<Recipe>> GetRecipesByExpired()
        {
            try
            {
                string userId = App.Current.Properties["userId"].ToString();

                HttpResponseMessage requestResult = await _httpClient.GetAsync($"Recipe/user/{userId}/product/expired");

                if (requestResult.IsSuccessStatusCode)
                {
                    string stringResult = await requestResult.Content.ReadAsStringAsync();

                    return JsonSerializer.Deserialize<List<Recipe>>(stringResult, _options);
                }
                else
                {
                    throw new Exception("Request error. Status code: " + requestResult.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<Recipe>();
        }
    }
}