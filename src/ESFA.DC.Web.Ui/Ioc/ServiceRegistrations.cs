using Autofac;
using DC.Web.Ui.Controllers;
using DC.Web.Ui.Services;
using DC.Web.Ui.Services.AppLogs;
using DC.Web.Ui.Services.ClaimHandlerService;
using DC.Web.Ui.Services.ServiceBus;
using DC.Web.Ui.Services.SubmissionService;
using Microsoft.Azure.ServiceBus;

namespace DC.Web.Ui.Ioc
{
    public class ServiceRegistrations : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(UkprnClaimHandlerService)).As(typeof(IUkprnClaimHandlerService))
                .InstancePerLifetimeScope();
            builder.RegisterType<ILRSubmissionController>().InstancePerLifetimeScope();

            builder.RegisterType<ServiceBusQueue>().As<IServiceBusQueue>().InstancePerLifetimeScope();
            builder.RegisterType<AppLogsReader>().As<IAppLogsReader>().InstancePerLifetimeScope();
            builder.RegisterType<ServiceBusQueueClient>().As<IQueueClient>().InstancePerLifetimeScope();

            builder.RegisterType<SubmissionService>().As<ISubmissionService>().InstancePerLifetimeScope();

        }

    }
}