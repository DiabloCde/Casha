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
            var services = new ServiceCollection();

            services.AddHttpClient<IAccountService, AccountService>(h =>
            {
                h.BaseAddress = new Uri("http://192.168.3.6:5128/api/");
                h.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddTransient<LoginViewModel>();
            services.AddTransient<RegisterViewModel>();

            var serviceProvider = services.BuildServiceProvider();

            ServiceProvider = serviceProvider;

            return serviceProvider;
        }

        public static T Resolve<T>() => ServiceProvider.GetService<T>();
    }
}
