using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class FakeCustomerRepository
    {
        private readonly IList<Customer> _customers;

        public FakeCustomerRepository()
        {
            this._customers = new List<Customer>();

            this.PopulateCustomers();
        }

        public IQueryable<Customer> Customers { get { return this._customers.AsQueryable(); } }

        public Customer GetCustomer(int id)
        {
            return this._customers.SingleOrDefault(x => x.Id == id);
        }

        public IList<Customer> GetCustomers()
        {
            return this._customers;
        }

        private void PopulateCustomers()
        {
            this._customers.Add(new Customer
            {
                Id = 1,
                Name = "Spencer Group",
                Address = new Address
                {
                    Id = 1,
                    Street = "776 Clifton Well",
                    City = "North Feltonland",
                    State = "New Hampshire",
                    Zip = 17163
                },
                Orders = new List<Order>
                        {
                            new Order
                                {
                                    Id = 1,
                                    Description = "Office Supplies Purchase Order",
                                    OrderItems = new List<OrderItem>
                                        {
                                            new OrderItem
                                                {
                                                    Id = 1,
                                                    LineNumber = 1,
                                                    Description = "Stapler",
                                                    Quantity = 2,
                                                    Price = 10.0m,
                                                    ExtendedTotal = 20.0m
                                                },
                                            new OrderItem
                                                {
                                                    Id = 2,
                                                    LineNumber = 2,
                                                    Description = "Tape Dispenser",
                                                    Quantity = 1,
                                                    Price = 10.0m,
                                                    ExtendedTotal = 10.0m
                                                },
                                        }
                                }
                        }
            });

            this._customers.Add(new Customer
            {
                Id = 2,
                Name = "Jones Oil Company",
                Address = new Address
                {
                    Id = 2,
                    Street = "123 Main Street",
                    City = "North Feltonland",
                    State = "New Hampshire",
                    Zip = 17163
                },
                Orders = new List<Order>
                        {
                            new Order
                                {
                                    Id = 2,
                                    Description = "Office Supplies Purchase Order",
                                    OrderItems = new List<OrderItem>
                                        {
                                            new OrderItem
                                                {
                                                    Id = 3,
                                                    LineNumber = 1,
                                                    Description = "Stapler",
                                                    Quantity = 2,
                                                    Price = 10.0m,
                                                    ExtendedTotal = 20.0m
                                                },
                                            new OrderItem
                                                {
                                                    Id = 4,
                                                    LineNumber = 2,
                                                    Description = "Tape Dispenser",
                                                    Quantity = 1,
                                                    Price = 10.0m,
                                                    ExtendedTotal = 10.0m
                                                },
                                        }
                                }
                        }
            });
        }
    }
}
