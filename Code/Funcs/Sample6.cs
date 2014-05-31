using System;

namespace Funcs
{
    public static partial class Samples
    {
        public static void Sample6()
        {
            var factor = 2;

            Func<int, int> multiplier = x => x * factor;

            factor = 10;

            Console.WriteLine(multiplier(3));
            Console.ReadLine();
        }
    }
}
