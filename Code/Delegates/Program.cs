using System;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Simple_Delegates();
            //Pass_Delegate_As_Function_Parameter();

            Console.ReadLine();
        }

        #region Setup
        static int Square(int x)
        {
            return x * x;
        }

        static int Increment(int x)
        {
            return x + 1;
        }
        #endregion

        #region Sample 1
        private delegate int DelegateA(int x);
        private delegate int DelegateB(int x);

        public static void Simple_Delegates()
        {
            DelegateA delegateA = new DelegateA(Square);
            DelegateB delegateB = Increment;

            var resultA = delegateA(3);
            var resultB = delegateB(3);

            Console.WriteLine("   Square: {0}", resultA);
            Console.WriteLine("Increment: {0}", resultB);
        }
        #endregion

        #region Sample 2
        private delegate int Transformer(int x);

        public static void Pass_Delegate_As_Function_Parameter()
        {
            Transformer squarer = Square;

            int[] values = { 1, 2, 3 };

            var results = Processor(values, squarer);

            Console.WriteLine("{0}, {1}, {2}", results[0], results[1], results[2]);
        }

        static int[] Processor(int[] values, Transformer transformer)
        {
            for (var i = 0; i < values.Length; i++)
            {
                values[i] = transformer(values[i]);
            }

            return values;
        }
        #endregion
    }
}
