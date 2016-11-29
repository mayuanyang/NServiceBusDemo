using System;
using System.Threading.Tasks;
using Topshelf;

namespace NServiceBusDemo.Service
{
    public class Program
    {
        static void Main()
        {
            AsyncMain().GetAwaiter().GetResult();
        }

        private async static Task AsyncMain()
        {

            var service = new DemoService();
            await service.Start();
            Console.Read();

        }
    }
}
