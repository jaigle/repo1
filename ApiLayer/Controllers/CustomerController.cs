using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiLayer.Library;
using Test.Entities;
using Test.Repository;
using Test.Repository.Interfaces;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : ApiController
    {
        IRepository<Customer> _customerRepository;

        //public CustomerController(IRepository<Customer> customerRepository)
        //{
        //    _customerRepository = customerRepository;
        //}

        // GET: api/Customer
        public ResultModel GetCustomers([FromUri] string token)
        {
            ICustomerRepository _miRepositorio = new CustomerRepository();
            CustomerManager custManager = new CustomerManager(_miRepositorio);
            return custManager.GetAllCustomers(token);
        }

        // GET: api/Customer/5
        [Route("api/Customer/{id}")]
        public ResultModel Get(int id, [FromUri] string token) 
        {
            CustomerManager custManager = new CustomerManager((ICustomerRepository)_customerRepository);
            return custManager.GetCustomerById(id, token);
        }

        // POST: api/Customer
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
    }
}
