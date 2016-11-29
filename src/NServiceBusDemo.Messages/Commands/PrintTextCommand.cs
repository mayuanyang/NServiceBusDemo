using NServiceBus;

namespace NServiceBusDemo.Messages
{
    public class PrintTextCommand : ICommand
    {
        public string Text { get; }

        public PrintTextCommand(string text)
        {
            Text = text;
        }
    }
}
