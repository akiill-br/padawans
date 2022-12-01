using ApiResource.Application.Mappings;
using ApiResource.Application.Services;
using ApiResource.Application.Services.Interfaces;
using ApiResource.Domain.Authentication;
using ApiResource.Domain.Repositories;
using ApiResource.Infra.Data.Authentication;
using ApiResource.Infra.Data.Context;
using ApiResource.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiResource.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
                                                        options.UseNpgsql("Server=localhost;Port=5432;Database=resource;User Id=postgres;Password=postgres;"));
            
            services.AddScoped<IResourceRepository, ResourceRepository>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;

        }
        
        public static IServiceCollection AddService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDtoMapping));
            services.AddScoped<IResourceService, ResourceService>();
            services.AddScoped<IUserService, UserService>();
               
            return services;
        }
    }
}
