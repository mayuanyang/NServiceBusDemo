using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Pipeline;
using NServiceBusDemo.Service.Pipeline;

namespace NServiceBusDemo.Service
{
    class DemoService
    {
        public async Task Start()
        {
            var endpointConfiguration = new EndpointConfiguration("NServiceBusDemo.Service");
            endpointConfiguration.UseSerialization<JsonSerializer>();
            endpointConfiguration.UsePersistence<InMemoryPersistence>();
            endpointConfiguration.SendFailedMessagesTo("error");
            endpointConfiguration.EnableInstallers();
            endpointConfiguration.Pipeline.Register(new UnitOfWork(), "Unit of work");
            endpointConfiguration.Pipeline.Register(new LogMessage(), "Log message");
            var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
            transport.ConnectionString("host=localhost");

            await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);
        }

        public void Stop()
        {
            
        }
    }
}
