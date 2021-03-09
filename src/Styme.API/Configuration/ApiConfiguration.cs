using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Styme.Data.Repository;
using Styme.Domain.Interfaces.Repository;
using Styme.Service.Interfaces;
using Styme.Service.Services;
using Styme.Service.Models.InputModels;
using Styme.Domain.Entities;
using Styme.Service.Models.OutputModels;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using System;

namespace Styme.API.Configuration
{
    public static class ApiConfiguration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IRestaurantService, RestaurantService>(); 
            services.AddScoped<IMenuService, MenuService>();

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
                config.CreateMap<UpdateMenuInputModel, Menu>();

                config.CreateMap<Restaurant, RestaurantOutputModel>();
                config.CreateMap<Menu, MenuOutputModel>();
            }).CreateMapper());
        }

        public static void RegisterSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Styme.API", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
