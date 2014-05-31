using System.Collections.Generic;

namespace ObjectsAsTrees.Data
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }

        public IList<Order> Orders { get; set; }
    }
}
