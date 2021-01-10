using CustomerPanel.Models;
using CustomerPanel.ViewModels;
using System.Collections.Generic;

namespace CustomerPanel.Repository
{
    public interface ICustomerRepository
    {
        void AddCustomer(CustomerViewModel model);

        List<Customer> GetCustomers();
    }
}
