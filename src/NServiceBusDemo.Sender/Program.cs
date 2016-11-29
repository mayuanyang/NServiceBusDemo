using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBusDemo.Messages;

namespace NServiceBusDemo.Sender
{
    class Program
    {
        static void Main()
        {
            AsyncMain().GetAwaiter().GetResult();
        }

        static async Task AsyncMain()
        {
            var endpointConfiguration = new EndpointConfiguration("NServiceBusDemo.Sender");
            endpointConfiguration.UseTransport<RabbitMQTransport>();
            endpointConfiguration.UseSerialization<JsonSerializer>();
            endpointConfiguration.UsePersistence<InMemoryPersistence>();
            endpointConfiguration.SendFailedMessagesTo("error");
            endpointConfiguration.EnableInstallers();

            var endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);

            Console.WriteLine("Press Enter to exit...");
            var test = Console.ReadLine();

            await endpointInstance.Send("NServiceBusDemo.Service", new PrintTextCommand(test));
            //await endpointInstance.Publish(new PrintTextCommand(test));

            await endpointInstance.Stop()
                .ConfigureAwait(false);
        }
    }
}
