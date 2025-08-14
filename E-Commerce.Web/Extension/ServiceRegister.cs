using E_Commerce.Web.Factories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace E_Commerce.Web.Extension
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddSwigerService(this IServiceCollection Services)
        {
            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen(Options =>
            {
                Options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Name = "authraziation",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme ="Bearer",
                    Description ="You Must Added 'Bearer' and Space Before Token Please"
                });

                Options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Id ="Bearer" ,
                                Type= ReferenceType.SecurityScheme
                            }
                        }, new string[] {}
                    }
                });
            });
            return Services;
        }


        public static IServiceCollection AddWebAppictionService(this IServiceCollection Services)
        {
            Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = ApiResponseFactory.ValidtionErrorResponse;
            });
            return Services;
        }


        public static IServiceCollection AddJWTService(this IServiceCollection Services , IConfiguration _configuration)
        {
            Services.AddAuthentication(Config =>
            {
                Config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                Config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;//Challenge ==> Compare When Return
            }).AddJwtBearer(options =>
            {
                //options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["JWTOptions:issuer"],

                    ValidateAudience = true,
                    ValidAudience = _configuration["JWTOptions:audience"],

                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWTOptions")["SecritKey"]!)) 
                };
            });

            return Services;
        }

    }
}   
