using DoctorConsultApp.Services;
using DoctorConsultDBContext.Models;
using DoctorConsultDBContext.Services;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorConsultApp
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

            services.AddControllers();
            services.AddMvc();
            //MvcOptions.EnableEndpointRouting = false;
            services.AddTransient<IDoctorConsultAppServices, DoctorConsultAppServices>();
            services.AddScoped<IDoctorConsultAppDBServices, DoctorConsultAppDBServices>();
            var connectionstring = Configuration.GetConnectionString("DefaultConnectionString");
            services.AddDbContext<DoctorConsultationAppDBContext>(options => options.UseSqlServer(connectionstring));
            //services.AddOData();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DoctorConsultApp", Version = "v1" });
                
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DoctorConsultApp v1"));
            }

            app.UseRouting();

            app.UseAuthorization();
            //app.UseHttpsRedirection();
            //app.UseMvc(routeBuilder =>
            //{
            //      routeBuilder.EnableDependencyInjection();
            //      routeBuilder.Select().OrderBy().Filter();
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
               // endpoints.Select().OrderBy().Filter();
            });
        }
    }
}
