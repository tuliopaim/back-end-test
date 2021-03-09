using Microsoft.Extensions.DependencyInjection;
using Styme.Data.Repository;
using Styme.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Styme.API.Configuration
{
    public static class DIConfiguration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
        }
    }
}
