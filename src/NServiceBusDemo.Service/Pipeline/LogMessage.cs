using System;
using System.Threading.Tasks;
using NServiceBus.Pipeline;

namespace NServiceBusDemo.Service.Pipeline
{
    class LogMessage : Behavior<IIncomingLogicalMessageContext>
    {
        public override async Task Invoke(IIncomingLogicalMessageContext context, Func<Task> next)
        {
            Console.WriteLine("Message logged");
            await next();
            
        }
    }
}
