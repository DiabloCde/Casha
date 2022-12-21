using CashaMobile.Models;
using CashaMobile.Services;
using CashaMobile.Services.Interfaces;
using CashaMobile.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashaMobile
{
    public static class Startup
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static IServiceProvider Init()
        {
            Uri apiAddress = new Uri("http://192.168.0.102:5128/api/");
            var services = new ServiceCollection();

            services.AddHttpClient<IAccountService, AccountService>(h =>
            {
                h.BaseAddress = apiAddress;
                h.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddHttpClient<IUserProductService, UserProductService>(h =>
            {
                h.BaseAddress = apiAddress;
                h.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddHttpClient<IRecipeService, RecipeService>(h =>
            {
                h.BaseAddress = apiAddress;
                h.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddTransient<LoginViewModel>();
            services.AddTransient<RegisterViewModel>();
            services.AddTransient<FridgeViewModel>();
            services.AddTransient<RecipesViewModel>();
            services.AddTransient<RecipesByProductViewModel>();

            var serviceProvider = services.BuildServiceProvider();

            ServiceProvider = serviceProvider;

            return serviceProvider;
        }

        public static T Resolve<T>() => ServiceProvider.GetService<T>();
    }
}
