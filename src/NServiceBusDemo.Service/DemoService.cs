using System.Threading.Tasks;
using NServiceBus;

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
            var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
            transport.ConnectionString("host=localhost");

            await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);
        }

        public void Stop()
        {
            
        }
    }
}
