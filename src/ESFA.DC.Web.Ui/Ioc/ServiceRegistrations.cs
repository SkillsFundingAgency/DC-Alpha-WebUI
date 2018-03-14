using Autofac;
using DC.Web.Ui.Controllers;
using DC.Web.Ui.Services;
using DC.Web.Ui.Services.Interfaces;
using DC.Web.Ui.Services.ServiceBus;

namespace DC.Web.Ui.Ioc
{
    public class ServiceRegistrations : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(UkprnClaimHandlerService)).As(typeof(IUkprnClaimsHandlerService))
                .InstancePerLifetimeScope();
            builder.RegisterType<ILRSubmissionController>().InstancePerLifetimeScope();

            builder.RegisterType(typeof(ServiceBusQueue)).As(typeof(IServiceBusQueue)).InstancePerLifetimeScope();
        }
    }
}