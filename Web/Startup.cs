using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using TestCore5.Data;
using TestCore5.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Data.Context;
using MediatR;
using Data.Base;
using Domain.Base;
using System;
using Amazon.S3;
using Web.Controllers;
using DataInFile.Base;
//Esto es un comentario de prueba

namespace TestCore5
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
            services.AddAWSService<IAmazonS3>();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("PalmAppContext")));

            services.AddDefaultIdentity<ApplicationUser>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer().AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            InyeccionPalmAppContext(services);
            InyeccionesGenericas(services);
            InyeccionesEspecificas(services);

            services.AddAuthentication()
                .AddIdentityServerJwt();
            services.AddControllersWithViews();
            services.AddRazorPages();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });


        }

        private void InyeccionPalmAppContext(IServiceCollection services)
        {
            var palmApp = Configuration.GetConnectionString("PalmAppContext");
            services.AddDbContext<PalmAppContext>(opt => opt.UseSqlServer(palmApp));
        }

        private void InyeccionesGenericas(IServiceCollection services)
        {
            services.Scan(scan =>
                    scan.FromAssemblies(Assembly.Load($"Domain"))
                    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
                        .AsImplementedInterfaces()
                            .WithTransientLifetime());

            services.Scan(scan =>
                    scan.FromAssemblies(Assembly.Load($"Aplication"))
                    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
                        .AsImplementedInterfaces()
                            .WithTransientLifetime());
        }

        private void InyeccionesEspecificas(IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.Load("Aplication"));

            services.AddScoped<IPalmAppUnitOfWork, PalmAppInFileUnitOfWork>();
            
            services.AddScoped<IRepositoryAbstractFactory, RepositoryInFileAbstractFactory>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                    //spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
