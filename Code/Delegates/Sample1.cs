using System;

namespace Delegates
{
    public static partial class Samples
    {
        private delegate int DelegateA(int x);
        private delegate int DelegateB(int x);

        public static void Sample1()
        {
            DelegateA delegateA = new DelegateA(Square);
            DelegateB delegateB = Increment;

            var resultA = delegateA(3);
            var resultB = delegateB(3);

            Console.WriteLine("   Square: {0}", resultA);
            Console.WriteLine("Increment: {0}", resultB);
            Console.ReadLine();
        }

        static int Square(int x)
        {
            return x * x;
        }

        static int Increment(int x)
        {
            return x + 1;
        }
    }
}
