using MarketPrices.Application.Features.MarketItem.Commands.CreateMarketItemQuantity;
using MarketPrices.Application.Features.MarketItem.Queries.GetMarketItems;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MarketPrices.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Cfg => Cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies())); 
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(CreateMarketItemQuantityCommand)));
            return services;
        }
    }
}