using System;
using System.Collections.Generic;
using System.Text;
using Test.Entities;

namespace Test.Repository.Interfaces
{
    public interface ICustomerRepository
        {
            IList<Customer> GetAllCustomers();
            Customer GetCustomerById(int id);
            void AddCustomer(Customer aCustomer);
        }
}
