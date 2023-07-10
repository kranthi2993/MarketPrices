using MarketPrices.Application.Contracts.Persistence;
using MarketPrices.Persistence.DBContext;
using MarketPrices.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MarketPrices.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<MarketDBContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("MarketDatabaseConnectionString"));
            });
        
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IMarketItemRepository, MarketItemRepository>();
            services.AddScoped<IMarketItemOfferRepository, MarketItemOfferRepository>();
            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<IMarketItemQuantityRepository, MarketItemQuantityRepository>();
            return services;

        }
    }
}