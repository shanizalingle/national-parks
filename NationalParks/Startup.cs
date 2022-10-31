using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NationalParks.Models;

namespace NationalParks
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

            services.AddDbContext<NationalParksContext>(opt =>
                opt.UseMySql(Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])));
            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
            options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "National Parks API",
                    Description = "An API containing locations, costs, activities and more on national parks",
                    Contact = new OpenApiContact
                    {
                        Name = "Shaniza Lingle",
                        Email = "shanizalingle@gmail.com",
                        Url = new Uri("https://github.com/shanizalingle/national-parks.git")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "License",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }

                });
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Shanizas API V1");
                    options.RoutePrefix = string.Empty;
                    // options.InjectStylesheet("/Assets/css/custom-swagger-ui.css"); 
                });
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}