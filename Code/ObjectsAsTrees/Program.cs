using ObjectsAsTrees.Data;

namespace ObjectsAsTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new FakeCustomerRepository();

            var customer = repository.GetCustomer(1);
        }
    }
}
