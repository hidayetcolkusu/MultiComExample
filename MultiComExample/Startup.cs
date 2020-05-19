using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseComManager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MultiComExample.Services;
using SerialComManager;
using TcpComManager;
using UdpComManager;

namespace MultiComExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddSingleton<IBaseListener<UdpDestInfo, UdpInitInfo>, UdpListener>();
            services.AddHostedService<UdpCommunicateService>();

            services.AddSingleton<IBaseListener<SerialDestInfo, SerialInitInfo>, SerialListener>();
            services.AddHostedService<SerialCommunicateService>();

            services.AddSingleton<IBaseListener<TcpDestInfo, TcpInitInfo>, TcpListener>();
            services.AddHostedService<TcpCommunicateService>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");                
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
