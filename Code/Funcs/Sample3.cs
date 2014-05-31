using System;

namespace Funcs
{
    public static partial class Samples
    {
        public static void Sample3()
        {
            Func<int, int, int> func1 = Add;
            Func<int, int, int> func2 = (x, y) => { return x + y; }; //Anonmyous Method
            Func<int, int, int> func3 = (x, y) => x + y;

            Console.WriteLine(func1(1, 2));
            Console.WriteLine(func2(1, 2));
            Console.WriteLine(func3(1, 2));
            Console.ReadLine();
        }

        static int Add(int x, int y)
        {
            return x + y;
        }
    }
}
