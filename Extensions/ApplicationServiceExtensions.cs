using AssetTrackingAPI.Interfaces;
using AssetTrackingAPI.Models;
using AssetTrackingAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetTrackingAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config) 
        {
            services.AddScoped<ITokenService, TokenService>();

            services.AddMvc();

            services.AddDbContext<AssetDBContext>(options => options.UseSqlServer(config.GetConnectionString("AssetDB")));

            return services;
        }
    }
}
