using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBusDemo.Messages;
using NServiceBusDemo.Messages.Events;

namespace NServiceBusDemo.Service.Handlers
{
    class PrintTextCommandHandler : IHandleMessages<PrintTextCommand>
    {
        public Task Handle(PrintTextCommand message, IMessageHandlerContext context)
        {
            Console.WriteLine(message.Text);
            context.Publish(new TextPrintedEvent(message.Text));
            return Task.FromResult(0);
        }
    }
}
