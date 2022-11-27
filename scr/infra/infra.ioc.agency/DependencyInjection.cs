using ApiDotNet6.Application.Mappings;
using ApiDotNet6.Application.Services;
using ApiDotNet6.Application.Services.Interfaces;
using ApiDotNet6.Domain.Repositories;
using ApiDotNet6.Infra.Data.Context;
using ApiDotNet6.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet6.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql("Server=localhost;Port=5432;Database=tablea;User Id=test;Password=teste;"));
            services.AddScoped<ITableARepository, TableARepository>();
            return services;
        }
        public static IServiceCollection AddService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDTOMapping));
            services.AddScoped<ITableAServices, TableAService>(); 
            return services;
        }
    }
}
