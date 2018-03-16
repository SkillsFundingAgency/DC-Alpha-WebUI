using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DC.Web.Ui.Services.ServiceBus;
using FluentAssertions;
using Microsoft.Azure.ServiceBus;
using Moq;
using Xunit;

namespace DC.Web.Ui.Services.Tests
{
    public class ServiceBusQueueTests
    {
        [Fact]
        public async  Task SendMessage_Success()
        {
            var queueClient = new Mock<IQueueClient>();
            queueClient.Setup(x => x.SendAsync(It.IsAny<Message>())).Returns(It.IsAny<Task>());
            queueClient.Setup(x => x.CloseAsync()).Returns(It.IsAny<Task>());

            var service = new ServiceBusQueue(queueClient.Object);

            var task = service.SendMessagesAsync(It.IsAny<string>(), It.IsAny<string>());
            task.RunSynchronously();

            task.IsCompletedSuccessfully.Should().BeTrue();
        }
    }
}
