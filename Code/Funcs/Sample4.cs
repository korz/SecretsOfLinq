using System;

namespace Funcs
{
    public static partial class Samples
    {
        public static void Sample4()
        {
            Func<dynamic> personFunc = () => new { FirstName = "Brian", LastName = "Korzynski" }; //Anonymous Type

            var person = personFunc();

            Console.WriteLine(person.FirstName + " " + person.LastName);
            Console.ReadLine();
        }
    }
}
