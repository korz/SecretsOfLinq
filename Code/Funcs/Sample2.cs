using System;

namespace Funcs
{
    public static partial class Samples
    {
        public static void Sample2()
        {
            Func<decimal, int> func = x =>
                {
                    x = x + 10;
                    return (int) x + 1;
                };
            
            Console.WriteLine(func(3.45m));
            Console.ReadLine();
        }
    }
}
