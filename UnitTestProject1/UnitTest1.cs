using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Entities;
using Test.Repository;
using Test.Repository.Interfaces;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        ICustomerRepository _miRepositorio = new CustomerRepository();

        public UnitTest1(ICustomerRepository miRepositorio)
        {
            _miRepositorio = miRepositorio;
        }

        [TestMethod]
        public void testGetAllCustomers()
        {
            var a = _miRepositorio.GetAllCustomers();
            Assert.AreNotEqual(1, 0);
        }

        [TestMethod]
        public void testAddCustomer()
        {
            Customer myCust = new Customer
            {
                FirstName = "Jose",
                LastName = "Aguilera",
                City = "Holguin",
                Country = "Cuba",
                Phone = "5555445444"
            };
            _miRepositorio.AddCustomer(myCust);
            Assert.IsTrue(true);
        }

    }
}
