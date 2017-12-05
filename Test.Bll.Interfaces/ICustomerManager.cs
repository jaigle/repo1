using System;
using System.Collections.Generic;
using Test.Entities;


namespace Test.Bll.Interfaces
{
    public interface ICustomerManager
    {
        ResultModel GetAllCustomers(string token);
        Customer GetCustomerById(int id);
        void AddCustomer(Customer aCustomer);
    }
}
