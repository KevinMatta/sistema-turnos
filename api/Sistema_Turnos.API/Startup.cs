using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Sistema_Turnos.API.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_Turnos.BusinessLogic;
using Sistema_Turnos.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Infrastructure;

namespace Sistema_Turnos.API
{
    public class Startup
    {
        /*swagger*/
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configurar la inyección de dependencias para DataAccess y BusinessLogic
            services.DataAccess(Configuration.GetConnectionString("Sistema_Turnos"));
            services.BusinessLogic();

            // Configurar AutoMapper
            services.AddAutoMapper(x => x.AddProfile<MappingProfileExtensions>(), AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();

            // Configurar Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sistema_Turnos.API", Version = "v1" });
            });

            // Configurar IHttpContextAccessor
            services.AddHttpContextAccessor();

            services.AddDistributedMemoryCache();

            // Configurar sesiones
            services.AddSession(options =>
            {
                options.Cookie.Name = ".MySession";
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.IsEssential = true;
            });

            // Configurar CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sistema_Turnos.API v1"));
            }

            app.UseHttpsRedirection();

            // Agregar el middleware de sesión antes de usar el middleware de enrutamiento
            app.UseSession();

            app.UseRouting();

            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}