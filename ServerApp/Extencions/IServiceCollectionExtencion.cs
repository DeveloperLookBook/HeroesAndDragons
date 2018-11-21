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
using ServerApp.ViewModels;

namespace ServerApp.Extencions
{
    static public class IServiceCollectionExtencion
    {
        static public IServiceCollection AddJwtAuthentication       (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
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
            var connection = @"Server=localhost;Database=HeroesAndDragons;Trusted_Connection=True;ConnectRetryCount=0";

            return services.AddDbContext<GameDbContext>(options => options.UseSqlServer(connection));
            //return services.AddDbContext<GameDbContext>(options => options.UseInMemoryDatabase("HeroesAndDragons"));
        }
        static public IServiceCollection AddRepositoryFactoryService(this IServiceCollection services)
        {
            return services.AddScoped<IRepositoryFactory, RepositoryFactory>();
        }
        static public IServiceCollection AddCommandHandlerService   (this IServiceCollection services)
        {
            return services.AddScoped<CommandHandler>();
        }
        static public IServiceCollection AddCommandFactoryService   (this IServiceCollection services)
        {
            return services.AddScoped<CommandFactory>();
        }
        static public IServiceCollection AddCorsPolicy              (this IServiceCollection services, string name)
        {
            if (name.IsNull      ()) { throw new ArgumentNullException(nameof(name)); }
            if (name.IsEmpty     ()) { throw new ArgumentException    (nameof(name)); }
            if (name.IsWhiteSpace()) { throw new ArgumentException    (nameof(name)); }

            return services.AddCors(options =>
            {
                options.AddPolicy(
                    name,
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }
    }
}
