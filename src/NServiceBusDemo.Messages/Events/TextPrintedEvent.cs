using NServiceBus;

namespace NServiceBusDemo.Messages.Events
{
    public class TextPrintedEvent : IEvent
    {
        public string Text { get; }

        public TextPrintedEvent(string text)
        {
            Text = text;
        }
    }
}
