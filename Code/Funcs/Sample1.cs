using System;

namespace Funcs
{
    public static partial class Samples
    {
        public static void Sample1()
        {
            Func<double> pi = () => GetPi();

            Func<double> pi2 = () => Math.PI;

            Console.WriteLine(pi());
            Console.WriteLine(pi2.Invoke());
            Console.ReadLine();
        }

        static double GetPi()
        {
            return Math.PI;
        }
    }
}
