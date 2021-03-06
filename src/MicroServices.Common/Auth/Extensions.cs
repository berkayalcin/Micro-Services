﻿using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace MicroServices.Common.Auth
{
    public static class Extensions
    {
        public static void AddJwt(this IServiceCollection collection, IConfiguration configuration)
        {
            var options=new JwtOptions();
            var section = configuration.GetSection("jwt");
            section.Bind(options);
            collection.Configure<JwtOptions>(section);
            collection.AddSingleton<IJwtHandler, JwtHandler>();
            collection.AddAuthentication().AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters=new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidIssuer = options.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey)),
                    

            };
            });
        }
    }
}