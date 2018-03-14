using DC.Web.Ui.Settings.Models;
using Microsoft.Azure.ServiceBus;
using System;
using System.Text;
using System.Threading.Tasks;

namespace DC.Web.Ui.Services.ServiceBus
{
    public class ServiceBusQueue : IServiceBusQueue
    {
        private readonly ServiceBusQueueSettings _serviceBusQueueSettings;

        public ServiceBusQueue(ServiceBusQueueSettings serviceBusQueueSettings)
        {
            _serviceBusQueueSettings = serviceBusQueueSettings;
        }

        public async Task SendMessagesAsync(string messageToSend, string sessionId)
        {
            try
            {
                var queueClient = new QueueClient(_serviceBusQueueSettings.ConnectionString, _serviceBusQueueSettings.Name);

                var message = new Message(Encoding.UTF8.GetBytes(messageToSend))
                {
                    SessionId = sessionId
                };

                // Send the message to the queue.
                await queueClient.SendAsync(message);
                await queueClient.CloseAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
                throw;
            }
        }
    }
}