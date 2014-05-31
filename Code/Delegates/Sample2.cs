using System;

namespace Delegates
{
    public static partial class Samples
    {
        private delegate int Tramsformer(int x);

        public static void Sample2()
        {
            Tramsformer squarer = Squared;

            int[] values = { 1, 2, 3 };

            var results = Processor(values, squarer);

            Console.WriteLine("{0}, {1}, {2}", results[0], results[1], results[2]);
            Console.ReadLine();
        }

        static int[] Processor(int[] values, Tramsformer tramsformer)
        {
            for (var i = 0; i < values.Length; i++)
            {
                values[i] = tramsformer(values[i]);
            }

            return values;
        }

        static int Squared(int value)
        {
            return value * value;
        }
    }
}
