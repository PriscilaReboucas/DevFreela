using DevFreela.API.Extensions;
using DevFreela.API.Filters;
using DevFreela.Application.Queries.GetUser;
using DevFreela.Application.Validators;
using DevFreela.Infrastructure.Persistence;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace DevFreela.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(o => o.Filters.Add(typeof(ValidationFilter)))
                 .AddFluentValidation(o =>
                     o.RegisterValidatorsFromAssemblyContaining<CreateUserInputModelValidator>());

            // Configurando EF Core
            var connectionString = Configuration.GetConnectionString("DevFreela");

            services.AddDbContext<DevFreelaDbContext>(options => options.UseSqlServer(connectionString));

            //services
            //    .AddDbContext<DevFreelaDbContext>(options => options.UseInMemoryDatabase("DevFreela"));


            // Quando utilizar interface utilizar a sua implementação, conseguindo utilizar interface sem depender da implementação concreta.
            // Realizando a injeção de dependência na startup. (AddRepositories)     

            services
                  .AddRepositories()
                  .AddMediatR(typeof(GetUserQuery));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "DevFreela.API",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Priscila Rebouças",
                        Email = "priscilaresantos@gmail.com",
                        Url = new Uri("https://www.google.com")
                    }
                });
            });

            //vou add autenticacao para meu sistema
            services
             .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,

                     ValidIssuer = Configuration["Jwt:Issuer"],
                     ValidAudience = Configuration["Jwt:Audience"],
                     IssuerSigningKey = new SymmetricSecurityKey
                   (Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                 };
             });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevFreela.API v1"));


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
