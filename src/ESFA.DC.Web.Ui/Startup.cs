using Autofac;
using Autofac.Extensions.DependencyInjection;
using DC.Web.Ui.Ioc;
using DC.Web.Ui.StartupConfiguration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace DC.Web.Ui
{
    public class Startup
    {
        private readonly IConfiguration _config;
        private readonly IHostingEnvironment _environment;
        private IContainer _applicationContainer;

        public Startup(IHostingEnvironment env)
        {
            _environment = env;
            var builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory());

            if (env.IsDevelopment())
            {
                builder.AddJsonFile($"appsettings.{Environment.UserName}.json");
            }
            else
            {
                builder.AddJsonFile("appsettings.json");
            }

            _config = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            if (_environment.IsDevelopment())
            {
                services.AddMvc(options =>
                {
                    options.Filters.Add(new AllowAnonymousFilter());
                });
            }
            else
            {
                services.AddMvc();
            }

            services.AddSession();
            services.AddAndConfigureAuthentication(_config);
            services.AddAndConfigureAuthorisation();
            services.AddMvc().AddControllersAsServices();

            
            return ConfigureAutofac(services);
        }

        private IServiceProvider ConfigureAutofac(IServiceCollection services)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule<ServiceRegistrations>();
            containerBuilder.SetupConfigurations(_config);

            containerBuilder.Populate(services);
            _applicationContainer = containerBuilder.Build();

            return new AutofacServiceProvider(_applicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();

                app.UseSession();
                app.UseAuthentication();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}