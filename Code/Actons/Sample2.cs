using System;

namespace Actions
{
    public static partial class Samples
    {
        public static void Sample2()
        {
            Action<string> action1 = (x) => PrintMessage(x);

            Action<string> action2 = x => PrintMessage(x);

            Action<int> action3 = x => PrintMessage(x.ToString());

            Action<string, string> action4 = (x, y) => PrintMessage(x, y);
            Action<string, string, string> action5 = (x, y, z) => PrintMessage(x, y, z);

            action1("Hello ");
            action2("self.conference ");
            action3(2014);

            action4("Hello ", "self.conference");
            action5("Hello ", "self.conference ", "2014");

            Console.ReadLine();
        }

        private static void PrintMessage(params string[] text)
        {
            foreach (var item in text)
            {
                Console.Write(item);
            }

            Console.WriteLine();
        }
    }
}
