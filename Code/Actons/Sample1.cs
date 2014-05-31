using System;

namespace Actions
{
    public static partial class Samples
    {
        public static void Sample1()
        {
            Action helloPrinter = () => PrintHello();

            helloPrinter();
            helloPrinter.Invoke();
            Console.ReadLine();
        }

        private static void PrintHello()
        {
            Console.WriteLine("Hello World!");
        }
    }
}
