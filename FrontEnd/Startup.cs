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

namespace FrontEnd
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
            services.AddRazorPages();
            services.AddControllersWithViews();
            services.AddSingleton<RepositorioCliente>(new RepositorioCliente(new Persistencia.AppRepositorios.AppContext()));
            services.AddSingleton<RepositorioEmpresa>(new RepositorioEmpresa(new Persistencia.AppRepositorios.AppContext()));
            services.AddSingleton<RepositorioPersona>(new RepositorioPersona(new Persistencia.AppRepositorios.AppContext()));
            services.AddSingleton<RepositorioEmpleado>(new RepositorioEmpleado(new Persistencia.AppRepositorios.AppContext()));
            services.AddSingleton<RepositorioDirectivo>(new RepositorioDirectivo(new Persistencia.AppRepositorios.AppContext()));
            services.AddSingleton<RepositorioUsuario>(new RepositorioUsuario(new Persistencia.AppRepositorios.AppContext()));
            services.AddSingleton<RepositorioRol>(new RepositorioRol(new Persistencia.AppRepositorios.AppContext()));
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
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapRazorPages());
        }
    }
}
