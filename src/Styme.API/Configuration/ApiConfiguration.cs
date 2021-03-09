using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Styme.Data.Repository;
using Styme.Domain.Interfaces.Repository;
using Styme.Service.Interfaces;
using Styme.Service.Services;
using Styme.Service.Models.InputModels;
using Styme.Domain.Entities;
using Styme.Service.Models.OutputModels;

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

                config.CreateMap<RestaurantOutputModel, Restaurant>();
                config.CreateMap<MenuOutputModel, Menu>();
            }).CreateMapper());
        }
    }
}
