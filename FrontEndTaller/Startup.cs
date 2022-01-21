using System.Net.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistencia.AppRepositorios;

namespace FrontEndTaller
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
            var _appContext = new Persistencia.AppRepositorios.AppContext();
            services.AddRazorPages();
            services.AddSingleton<RepositorioCliente>(new RepositorioCliente(_appContext));
            services.AddSingleton<RepositorioEmpresa>(new RepositorioEmpresa(_appContext));
            services.AddSingleton<RepositorioPersona>(new RepositorioPersona(_appContext));
            services.AddSingleton<RepositorioEmpleado>(new RepositorioEmpleado(_appContext));
            services.AddSingleton<RepositorioDirectivo>(new RepositorioDirectivo(_appContext));
            services.AddSingleton<RepositorioUsuario>(new RepositorioUsuario(_appContext));
            services.AddSingleton<RepositorioRol>(new RepositorioRol(_appContext));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
