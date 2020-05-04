using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Calaveras.Domain.Entities;
using Cavaleras.Api.Extensions.HealthChecks;
using Cavaleras.CrossCutting;
using Cavaleras.Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Cavaleras.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.AddSingleton<IConfiguration>(_configuration);

            services.AddSwaggerGen(gen =>
            {
                gen.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Manager Order Delivery",
                    Contact = new OpenApiContact
                    {
                        Email = "leandro.rodrigs11@gmail.com",
                        Name = "Leandro Rodrigues",
                        Url = new Uri("https://github.com/lerodrigs/cavaleras-backend")
                    },
                });

                gen.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Auhorization. Use Bearer + token",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                gen.IncludeXmlComments(xmlPath);
            });

            services.AddHealthChecks()
                .AddMemoryInfoHealthCheck("memory");

            services.AddDbContext<CavalerasDbContext>();
            services.AddIdentity<User, IdentityRole>(configUser =>
            {
                configUser.Password.RequireUppercase = false;
                configUser.Password.RequireDigit = false;
                configUser.Password.RequiredLength = 0;
                configUser.Password.RequiredUniqueChars = 0;
                configUser.Password.RequireNonAlphanumeric = false;

                configUser.User.RequireUniqueEmail = true; 
            })
                .AddEntityFrameworkStores<CavalerasDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwtOptions =>
            {
                jwtOptions.RequireHttpsMetadata = false;
                jwtOptions.SaveToken = true;
                jwtOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = _configuration["jwtSettings:issuer"],
                    ValidAudience = _configuration["jwtSettings:audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwtSettings:signingKey"])),
                    ClockSkew = TimeSpan.FromDays(1)
                };
            });

            DependencyInjectors.Inject(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(c => 
            { 
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHealthChecks("/check", new HealthCheckOptions
            {
                ResponseWriter = async (httpContext, healthReport) =>
                {
                    httpContext.Response.ContentType = "application/json";
                    JObject json = new JObject(
                        new JProperty("status", healthReport.Status.ToString()),
                        new JProperty("results", new JObject(healthReport.Entries.Select(pair => 
                            new JProperty(pair.Key, new JObject(
                                new JProperty("status", pair.Value.Status.ToString()),
                                new JProperty("description", pair.Value.Description), 
                                new JProperty("data", new JObject(pair.Value.Data.Select(p => 
                                    new JProperty(p.Key, p.Value))))))))));

                    await httpContext.Response.WriteAsync(json.ToString(Formatting.Indented));
                } 
            });

            app.UseHealthChecksUI();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
            

            DbSeedInitializer.CreateRoles(roleManager);
            DbSeedInitializer.CreateAdmin(userManager);
        }
    }
}
