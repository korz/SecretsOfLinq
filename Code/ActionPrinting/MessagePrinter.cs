using System;

namespace ActionPrinting
{
    internal static class MessagePrinter
    {
        public static void PrintMessage(params string[] text)
        {
            foreach (var item in text)
            {
                Console.Write(item);
            }

            Console.WriteLine();
        }
    }
}
