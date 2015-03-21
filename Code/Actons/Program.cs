using System;
using ActionPrinting;

namespace Actions
{
    class Program
    {
        public static void Main(string[] args)
        {
            Simple_Action();
            //Action_With_Single_Parameter();
            //Action_With_Multiple_Parameters();
            //Action_From_Another_Project();

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
            Action<string> action1 = (x) => PrintMessage(x);

            Action<string> action2 = x => PrintMessage(x);

            Action<int> action3 = x => PrintMessage(x.ToString());

            action1("Hello");
            action2("GRDevDay");
            action3(DateTime.Today.Year);
        }

        private static void PrintMessage(string text)
        {
            Console.WriteLine(text);
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

            action("Hello", "GRDevDay", DateTime.Today.Year);
        }

        public static void Action_From_Another_Project()
        {
            var actionCreator = new MessagePrintingActionCreator();

            actionCreator.Print("Hello GRDevDay 2015");
        }
    }
}
