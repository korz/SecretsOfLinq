using System;
using ActionPrinting;

namespace Actions
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Simple_Action();
            //Action_With_Single_Parameter();
            //Action_With_Multiple_Parameters();
            Action_From_Another_Project();

            Console.ReadLine();
        }

        public static void Simple_Action()
        {
            Action action = () => Console.WriteLine("Hello World!");

            action();
        }

        public static void Action_With_Single_Parameter()
        {
            //Different Styles, Same thing
            Action<string> action1 = (x) => Console.WriteLine(x);

            Action<string> action2 = x => Console.WriteLine(x);

            Action<int> action3 = x => Console.WriteLine(x.ToString());

            action1("Hello");
            action2("CodeStock");
            action3(DateTime.Today.Year);
        }

        public static void Action_With_Multiple_Parameters()
        {
            //Action<string, string> action = (x, y) => SomeMethod(x, y);

            Action<string, string, int> action = (x, y, z) =>
            {
                var text = string.Format("{0} {1} {2}", x, y, z);

                Console.Write(text);
                
                Console.WriteLine();
            };

            action("Hello", "CodeStock", DateTime.Today.Year);
        }

        public static void Action_From_Another_Project()
        {
            var actionCreator = new MessagePrintingActionFactory();

            actionCreator.Print("Hello CodeStock 2015");
        }
    }
}
