using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Test.Data.Abstractions;
using Test.Data.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Test.Web.Api
{
    [ExcludeFromCodeCoverage]
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

            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<EntityFrameWorkDbContext>
                (options => options.UseSqlServer(Configuration["ConnectionStrings:LocalDataBase"])/*, contextLifetime: ServiceLifetime.Singleton*/);

            services.AddScoped<IUnitOfWork, UnitOfWorkEF>();
            services.AddScoped<IUserRepository, UserRepositoryEF>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(options => options.WithOrigins(Configuration["Network:AllowedOrigins"].Split(';'))
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}
