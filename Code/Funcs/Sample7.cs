using System.Collections.Generic;
using System.Linq;
using ObjectsAsTrees.Data;

namespace Funcs
{
    public static partial class Samples
    {
        public static void Sample7()
        {
            var customers = GetCustomersFromDatabase();
        }

        public static void Test(IList<Customer> customers)
        {
            foreach (var customer in customers)
            {
                var otherCustomers = customers.Where(x => x != customer);
            }
        }

        public static void Test2(IList<Customer> customers)
        {
            foreach (var customer in customers)
            {
                var temp = customer;
                var otherCustomers = customers.Where(x => x != temp);
            }
        }

        private static IList<Customer> GetCustomersFromDatabase()
        {
            var repository = new FakeCustomerRepository();

            return repository.GetCustomers();
        }
    }
}
