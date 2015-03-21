using System;
using ObjectsAsTrees.Data;

namespace Funcs
{
    public static partial class Samples
    {
        public static void Sample5()
        {
            Func<Customer> getCustomerFunc = GetCustomerFromDatabase;
            Func<Customer, dynamic> convert = x => new
                {
                    CustomerName = x.Name, 
                    CustomerAddress = x.Address
                };

            var customer = convert(getCustomerFunc());

            Console.WriteLine(customer.CustomerName);
            Console.WriteLine(customer.CustomerAddress);
            Console.ReadLine();
        }

        private static Customer GetCustomerFromDatabase()
        {
            var repository = new FakeCustomerRepository();

            return repository.GetCustomer(1);
        }
    }
}
