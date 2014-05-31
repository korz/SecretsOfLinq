using System;

namespace ActionPrinting
{
    public class MessagePrintingActionCreator
    {
        public Action<string> Print { get; private set; }

        public MessagePrintingActionCreator()
        {
            this.Print = x => MessagePrinter.PrintMessage(x);
        }
    }
}
