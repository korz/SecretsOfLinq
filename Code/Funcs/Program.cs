using System;
using System.Collections.Generic;
using System.Linq;
using Data;

namespace Funcs
{
    class Program
    {
        static void Main(string[] args)
        {
            Simple_Func();
            //Func_With_Body();
            //Method_Groups_And_Anonymous_Methods();
            //Anonymous_Type();
            //Func_As_Converter();
            //Closure();
            ////Captured_Variable_Problem();

            Console.ReadLine();
        }

        #region Setup
        static int Add(int x, int y)
        {
            return x + y;
        }

        public static Customer GetCustomerFromDatabase()
        {
            var repository = new FakeCustomerRepository();

            return repository.GetCustomer(1);
        }

        public static IList<Customer> GetCustomersFromDatabase()
        {
            var repository = new FakeCustomerRepository();

            return repository.GetCustomers();
        }
        #endregion

        #region Sample 1
        public static void Simple_Func()
        {
            Func<double> pi = () => GetPi();

            Func<double> pi2 = () => Math.PI;

            Console.WriteLine(pi());
            Console.WriteLine(pi2.Invoke());
        }

        static double GetPi()
        {
            return Math.PI;
        }
        #endregion

        #region Sample 2
        public static void Func_With_Body()
        {
            Func<decimal, int> func = x =>
            {
                x = x + 10;
                return (int)x + 1;
            };

            Console.WriteLine(func(3.45m));
        }
        #endregion

        #region Sample 3
        public static void Method_Groups_And_Anonymous_Methods()
        {
            //Method Group???
            Func<int, int, int> func1 = (x, y) => Add(x, y);
            Func<int, int, int> func4 = Add;

            Func<int, int, int> func2 = (x, y) => 
            { 
                return x + y;
            }; //Anonmyous Method
            Func<int, int, int> func3 = (x, y) => x + y;

            Console.WriteLine(func1(1, 2));
            Console.WriteLine(func2(1, 2));
            Console.WriteLine(func3(1, 2));
        }
        #endregion

        #region Sample 4
        public static void Anonymous_Type()
        {
            Func<dynamic> personFunc = () =>  new
            {
                FirstName = "Brian",
                LastName = "Korzynski"
            }; //Anonymous Type

            var person = personFunc();

            Console.WriteLine(person.FirstName + " " + person.LastName);
        }
        #endregion

        #region Sample 5
        public static void Func_As_Converter()
        {
            var repository = new FakeCustomerRepository();
            var customer = repository.GetCustomers();

            Func<Customer, dynamic> converter = x => new
            {
                CustomerName = x.Name,
                CustomerAddress = x.Address
            };

            dynamic convertedCustomer = converter(customer);

            Console.WriteLine(convertedCustomer.CustomerName);
            Console.WriteLine(convertedCustomer.CustomerAddress);
        }
        #endregion

        #region Sample 6
        public static void Closure()
        {
            var factor = 2;

            Func<int, int> multiplier = x => x * factor;

            factor = 10;

            Console.WriteLine(multiplier(3));
        }
        #endregion

        #region Sample 7
        public static void Captured_Variable_Problem()
        {
            var customers = GetCustomersFromDatabase();

            foreach (var customer in customers)
            {
                var otherCustomers = customers.Where(x => x != customer);
            }
        }

        public static void Captured_Variable_Solution_1()
        {
            var customers = GetCustomersFromDatabase();

            foreach (var customer in customers)
            {
                var temp = customer;
                var otherCustomers = customers.Where(x => x != temp);
            }
        }

        public static void Captured_Variable_Solution_2()
        {
            var customers = GetCustomersFromDatabase();

            foreach (var customer in customers)
            {
                var otherCustomers = customers.Where(x => x != customer).ToList();
            }
        }
        #endregion
    }
}
