using System;
using DapperStore.Domain.StoreContext.Handlers;
using DapperStore.Domain.StoreContext.Repositories;
using DapperStore.Domain.StoreContext.Services;
using DapperStore.Infra.Services;
using DapperStore.Infra.StoreContext.DataConnection;
using DapperStore.Infra.StoreContext.Repositories;
using Elmah.Io.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DapperStore.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddResponseCompression();

            services.AddScoped<OracleDataConnection, OracleDataConnection>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler, CustomerHandler>();

            services.AddSwaggerGen(x => {
                x.SwaggerDoc("v1", new OpenApiInfo {Title = "My Api", Version = "v1"});
            });

            services.AddElmahIo(o =>
            {
                o.ApiKey = "bd77c1c4b77d41aba665e8503791108c";
                o.LogId = new Guid("8dc4b1e9-187e-49b2-83ba-a9bffaa3d7d0");
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });

            app.UseResponseCompression();
            app.UseSwagger();
            app.UseSwaggerUI( c=> {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dapper Store - V1");
            });

            app.UseElmahIo();
        }
    }
}
