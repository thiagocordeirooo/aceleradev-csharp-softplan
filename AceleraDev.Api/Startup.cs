using AceleraDev.Application.Mapping;
using AceleraDev.CrossCutting.Helpers;
using AceleraDev.CrossCutting.IoC;
using AceleraDev.Data.Context;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace AceleraDev.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. 
        // Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                // Desabilitar referência circular na serialiazção dos json
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            // Configuração da injeção de dependencias
            RegisterIoC.Register(services);

            // Configuração do AutoMapper
            services.AddAutoMapper(typeof(AutoMappingDomainToViewModel));
            services.AddAutoMapper(typeof(AutoMappingViewModelToDomain));

            // Configuração do contexto ef
            services.AddDbContext<AceleraDevContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Configuração do mongodb
            MongoDbContext.ConnectionString = Configuration.GetConnectionString("mongodb");

            ConfigureAuth(services);

            ConfigureSwagger(services);
        }

        private void ConfigureAuth(IServiceCollection services)
        {
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var secretKeyJWT = Encoding.ASCII.GetBytes(appSettings.SecretKeyJWT);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.ClaimsIssuer = "api.aceleradev.com";
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKeyJWT),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                };
            });
        }

        [Obsolete]
        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API AceleraDev",
                    Version = "1.0.0",
                    License = new OpenApiLicense
                    {
                        Url = new Uri("http://api.thiagocordeiro.tech/licence")
                    },
                    Description = "API para fornecimento de dados para execuções funcionalidades do AceleraDev.</br>",
                    Contact = new OpenApiContact
                    {
                        Name = "Thiago Cordeiro",
                        Email = "thiagocordeirooo@gmail.com",
                        Url = new Uri("http://www.thiagocordeiro.tech")
                    }
                });

                config.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "API AceleraDev NEW",
                    Version = "2.0.0",
                    License = new OpenApiLicense
                    {
                        Url = new Uri("http://api.thiagocordeiro.tech/licence")
                    },
                    Description = "API para fornecimento de dados para execuções funcionalidades do AceleraDev.</br>",
                    Contact = new OpenApiContact
                    {
                        Name = "Thiago Cordeiro",
                        Email = "thiagocordeirooo@gmail.com",
                        Url = new Uri("http://www.thiagocordeiro.tech")
                    }
                });

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header usando Bearer scheme. Exemplo: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                config.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                BearerFormat = "Bearer {access token}",
                                Name = "Bearer",
                                In = ParameterLocation.Header,

                            },

                            new List<string>()
                        }
                    });

                // Para funcionar a leitura do .xml de documentação é preciso habilitar nas configurações do projeto:
                // https://docs.microsoft.com/pt-br/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {

                config.SwaggerEndpoint("/swagger/v1/swagger.json", "API - AceleraDev V1");
                config.SwaggerEndpoint("/swagger/v2/swagger.json", "API - AceleraDev V2");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
