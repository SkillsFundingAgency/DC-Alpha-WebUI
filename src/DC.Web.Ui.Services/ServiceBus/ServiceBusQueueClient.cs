using System;
using System.Collections.Generic;
using System.Text;
using DC.Web.Ui.Settings.Models;
using Microsoft.Azure.ServiceBus;

namespace DC.Web.Ui.Services.ServiceBus
{
    public class ServiceBusQueueClient : QueueClient
    {
        public ServiceBusQueueClient(ServiceBusQueueSettings serviceBusQueueSettings):
            base(serviceBusQueueSettings.ConnectionString,serviceBusQueueSettings.Name)
        {

        }
    }
}
