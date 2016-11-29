using System;
using System.Threading.Tasks;
using NServiceBus.Pipeline;

namespace NServiceBusDemo.Service.Pipeline
{
    class UnitOfWork : Behavior<IIncomingLogicalMessageContext>
    {
        public override async Task Invoke(IIncomingLogicalMessageContext context, Func<Task> next)
        {
            Console.WriteLine("Unit of work started");
            await next();
            Console.WriteLine("Unit of work committed");
        }
    }
}
