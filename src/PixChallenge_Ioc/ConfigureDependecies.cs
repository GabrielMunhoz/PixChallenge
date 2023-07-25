using Microsoft.Extensions.DependencyInjection;
using PixChallenge_Application.Interfaces;
using PixChallenge_Application.Services;
using PixChallenge_Core.Interfaces;
using PixChallenge_Data.Repository;

namespace PixChallenge_Ioc
{
    public static class ConfigureDependecies
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services) {
            services.AddTransient<IBankTransactionService, BankTransactionService>();
            services.AddTransient<IAccountHolderService, AccountHolderService>();
            
            return services;
        }

        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBankTransactionRepository, BankTransactionRepository>();
            services.AddScoped<IAccountHolderRepository, AccountHolderRepository>();

            return services;
        }
    }
}