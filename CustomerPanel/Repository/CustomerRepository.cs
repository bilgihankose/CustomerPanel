using CustomerPanel.Context;
using CustomerPanel.Models;
using CustomerPanel.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CustomerPanel.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CafeManagementContext _cafeManagementContext;

        public CustomerRepository(CafeManagementContext cafeManagementContext)
        {
            _cafeManagementContext = cafeManagementContext;
        }

        public void AddCustomer(CustomerViewModel model)
        {
            Customer newCustomer = new Customer()
            {
                
            };

            newCustomer.Name = model.Name;
            newCustomer.Surname = model.Surname;
            newCustomer.Tc = model.Tc;
            newCustomer.Year = model.Year;
            newCustomer.CafeId = model.CafeId;

            _cafeManagementContext.Customers.Add(newCustomer);

            _cafeManagementContext.SaveChanges();

         
        }

        public List<Customer> GetCustomers()
        {
            return _cafeManagementContext.Customers.ToList();
        }
    }
}