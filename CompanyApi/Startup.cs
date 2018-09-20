using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using TobitLogger.Core;
using TobitLogger.Logstash;
using CompanyApi.Interfaces;
using CompanyApi.Repository;
using CompanyApi.Model;
using CompanyApi.Model.dto;
using TobitWebApiExtensions.Extensions;

namespace CompanyApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Config;
        public Startup(IConfiguration configuration)
        {
            Config = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            

            services.Configure<DbSettings>(Config.GetSection("DbSettings"));

            services.AddSingleton<IDbContext, Helper.DbContext>();
            services.AddSingleton<IAuthorization, Helper.Authorization>();

            services.AddScoped<IRepository<Address, AddressDto>, AddressRepo>();
            services.AddScoped<IRepository<City, CityDto>, CityRepo>();
            services.AddScoped<IRepository<Company, CompanyDto>, CompanyRepo>();
            services.AddScoped<IRepository<Department, DepartmentDto>, DepartmentRepo>();
            services.AddScoped<IRepository<Employee, EmployeeDto>, EmployeeRepo>();

            services.AddChaynsToken();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
