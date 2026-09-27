using Microsoft.Extensions.DependencyInjection;
using ProductApp.Application.Interface.Services;
using ProductApp.Application.Mappings;
using ProductApp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddProfile<ProductProfile>());
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}
