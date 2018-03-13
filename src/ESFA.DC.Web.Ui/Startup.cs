using DC.Web.Ui.Settings;
using DC.Web.Ui.StartupConfiguration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DC.Web.Ui
{
    public class Startup
    {
        private readonly IConfigurationRoot _config;
        private readonly IHostingEnvironment _environment;

        public Startup(IHostingEnvironment env)
        {
            _environment = env;
            var builder = new ConfigurationBuilder();

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }
            else
            {
                builder.AddJsonFile("appsettings.json");
            }

            _config = builder.Build();

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //var authSettings = _config.GetSection("AuthenticationSettings").Get<AuthenticationSettings>();

            var authSettings = new AuthenticationSettings();
            authSettings.WtRealm = _config["AuthenticationSettings:realm"];
            authSettings.MetadataAddress = _config["AuthenticationSettings:metadata"];

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

            services.AddAndConfigureAuthentication(authSettings);
            services.AddAndConfigureAuthorisation();
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