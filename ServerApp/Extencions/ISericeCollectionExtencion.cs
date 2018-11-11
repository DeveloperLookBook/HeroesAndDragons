using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ServerApp.Data;
using ServerApp.Data.Repositories;
using ServerApp.Data.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerApp.Data.Receivers;
using ServerApp.Data.Commands;

namespace ServerApp.Extencions
{
    static public class ISericeCollectionExtencion
    {
        static public IServiceCollection AddJwtAuthentication       (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer           = true,
                            ValidIssuer              = configuration["Jwt:Issuer"  ],

                            ValidateAudience         = true,
                            ValidAudience            = configuration["Jwt:Audience"],

                            ValidateLifetime         = true,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey         = JwtSecurityKeyFactory.Create(configuration["Jwt:Key"])
                        };
                    });

            return services;
        }
        static public IServiceCollection AddConfigurationService    (this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddSingleton(configuration);
        }
        static public IServiceCollection AddInMememoryDbContext     (this IServiceCollection services)
        {
            return services.AddDbContext<GameDbContext>(options => options.UseInMemoryDatabase("HeroesAndDragons"));
        }
        static public IServiceCollection AddRepositoryFactoryService(this IServiceCollection services)
        {
            return services.AddSingleton<IRepositoryFactory, RepositoryFactory>();
        }
        static public IServiceCollection AddCommandHandlerService   (this IServiceCollection services)
        {

            return services.AddSingleton<CommandHandler, CommandHandler>();
        }
        static public IServiceCollection AddCommandFactoryService   (this IServiceCollection services)
        {
            return services.AddSingleton<CommandFactory, CommandFactory>();
        }
    }
}
