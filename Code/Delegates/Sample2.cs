using System;

namespace Delegates
{
    public static partial class Samples
    {
        private delegate int Transformer(int x);

        public static void Sample2()
        {
            Transformer squarer = Squared;

            int[] values = { 1, 2, 3 };

            var results = Processor(values, squarer);

            Console.WriteLine("{0}, {1}, {2}", results[0], results[1], results[2]);
            Console.ReadLine();
        }

        static int[] Processor(int[] values, Transformer transformer)
        {
            for (var i = 0; i < values.Length; i++)
            {
                values[i] = transformer(values[i]);
            }

            return values;
        }

        static int Squared(int value)
        {
            return value * value;
        }
    }
}
