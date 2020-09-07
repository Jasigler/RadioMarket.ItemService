using DataLayer.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Models.Interfaces;
using Services;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using HealthCheck.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Radiomarket.Itemservice
{
    public class Startup
    {
        readonly string AllowSpecificOrigins = "_allowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddDbContext<ItemContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("ItemConnection"));
            });
            services.AddAutoMapper(typeof(Startup));
            services.TryAddScoped<IItemRepository, ItemRepository>();
            services.AddHealthChecksUI(options =>
            {
                options.AddHealthCheckEndpoint("main", "https://localhost:92/health");
            }).AddInMemoryStorage();

            services.AddHealthChecks()
                .AddCheck<MemoryHealthCheck>("memory", tags: new[] { "memory" })
                .AddNpgSql(Configuration.GetConnectionString("ItemConnection"),
                    healthQuery: "SELECT 1",
                    name: "sql",
                    failureStatus: HealthStatus.Unhealthy,
                    tags: new[] { "database" });

            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowSpecificOrigins,
                    builder =>
                        builder.WithOrigins("localhost").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
                            
            });

            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
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

            app.UseCors(AllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecksUI();
                endpoints.MapHealthChecks("health", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
                
            });
        }
    }
}
