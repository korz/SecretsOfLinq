using System;
using ActionPrinting;

namespace Actions
{
    public static partial class Samples
    {
        public static void Sample3()
        {
            var actionCreator = new MessagePrintingActionCreator();

            actionCreator.Print("Hello self.conference 2014");

            Console.ReadLine();
        }
    }
}
