using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Styme.Data.Repository;
using Styme.Domain.Interfaces.Repository;
using Styme.Service.Interfaces;
using Styme.Service.Services;
using Styme.Service.Models;
using Styme.Service.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Styme.Domain.Entities;

namespace Styme.API.Configuration
{
    public static class ApiConfiguration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IRestaurantService, RestaurantService>(); 

            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();

            services.RegisterMappers();
        }

        public static void RegisterMappers(this IServiceCollection services)
        {
            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<NewRestaurantInputModel, Restaurant>();
                config.CreateMap<UpdateRestaurantInputModel, Restaurant>();
                config.CreateMap<NewMenuInputModel, Menu>();
            }).CreateMapper());
        }
    }
}
