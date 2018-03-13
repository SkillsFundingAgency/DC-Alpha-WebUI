using DC.Web.Ui.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.WsFederation;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace DC.Web.Ui.StartupConfiguration
{
    public static class AuthenticationStartup
    {
        public static void AddAndConfigureAuthentication(this IServiceCollection services, IAuthenticationSettings configuration)
        {
            services.AddAuthentication(sharedOptions =>
                {
                    sharedOptions.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    sharedOptions.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    sharedOptions.DefaultChallengeScheme = WsFederationDefaults.AuthenticationScheme;
                    sharedOptions.DefaultSignOutScheme = WsFederationDefaults.AuthenticationScheme;
                })
                .AddWsFederation(options =>
                {
                    options.Wtrealm = configuration.WtRealm;
                    options.MetadataAddress = configuration.MetadataAddress;

                    options.Events.OnSecurityTokenValidated = OnTokenValidated;
                    options.CallbackPath = "/Account/SignedIn";
                })
                .AddCookie(options => { options.ReturnUrlParameter = "/Account/SignedIn"; });
        }

        private static Task OnTokenValidated(SecurityTokenValidatedContext context)
        {
            return Task.CompletedTask;
        }
    }
}