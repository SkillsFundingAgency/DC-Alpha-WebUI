using DC.Web.Ui.ClaimTypes;
using Microsoft.Extensions.DependencyInjection;

namespace DC.Web.Ui.StartupConfiguration
{
    public static class AuthorisationStartup
    {
        public static void AddAndConfigureAuthorisation(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                //options.AddPolicy(PolicyTypes.Ukprn, policy => policy.Requirements.Add(new UkprnRequirement()));
                options.AddPolicy(PolicyTypes.FileSubmission, policy => policy.RequireClaim(IdamsClaimTypes.Ukprn));
            });
        }
    }
}
