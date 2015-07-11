using System;

namespace ActionPrinting
{
    public class MessagePrintingActionFactory
    {
        public Action<string> Print { get; private set; }

        public MessagePrintingActionFactory()
        {
            this.Print = x => MessagePrinter.PrintMessage(x);
        }
    }
}
