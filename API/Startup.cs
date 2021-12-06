using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infraestructura.Datos.Repository;
using API.Services;
using Infraestructura.Datos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace API
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
            
            var connectionString=Configuration.GetConnectionString("DefaultConnection");
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseMySql(connectionString,ServerVersion.AutoDetect(connectionString))
                .Options;

            services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)) );
            services.AddControllers();
             Task.Run(() => {
               BaseDeDatosSeed.SeedAsync(new ApplicationDbContext(contextOptions),new LoggerFactory()).Wait();     
        });
            
                 
            //----------------------------------------
            services.AddScoped<ILugarRepository,LugarRepository>(); //AddScoped , dura el tiempo del request 
            //AddSingleton tiene un ciclo de vida mas largo, se reutiliza.
            //AddTransient = ciclo de vida corto se crea cada vez que se invoca  la dependencia.
      
                         
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }
            


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}
