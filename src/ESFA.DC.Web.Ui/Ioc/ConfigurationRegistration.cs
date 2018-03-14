using Autofac;
using DC.Web.Ui.Services.Models;
using DC.Web.Ui.Settings.Models;
using Microsoft.Extensions.Configuration;

namespace DC.Web.Ui.Ioc
{
    public static class ConfigurationRegistration
    {
        public static void SetupConfigurations(this ContainerBuilder builder, IConfiguration configuration)
        {
            builder.Register(c =>
                configuration.GetSection("CloudStorageSettings").Get<CloudStorageSettings>())
                .As<CloudStorageSettings>().SingleInstance();

            builder.Register(c =>
                    configuration.GetSection("ServiceBusQueueSettings").Get<ServiceBusQueueSettings>())
                .As<ServiceBusQueueSettings>().SingleInstance();
        }
    }
}