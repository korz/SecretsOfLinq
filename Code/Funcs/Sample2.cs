using System;

namespace Funcs
{
    public static partial class Samples
    {
        public static void Sample2()
        {
            Func<int, int> func1 = Increment;
            Func<int, int> func2 = x => x + 1;
            Func<decimal, int> func3 = x => (int)x + 1;
            
            Console.WriteLine(func1(3));
            Console.WriteLine(func2(3));
            Console.WriteLine(func3(3));
            Console.ReadLine();
        }

        static int Increment(int x)
        {
            return x + 1;
        }
    }
}
