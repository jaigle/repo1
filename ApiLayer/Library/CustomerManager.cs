using System.Collections.Generic;
using Newtonsoft.Json;
using Test.Entities;
using Test.Repository.Interfaces;

namespace ApiLayer.Library
{
    public class CustomerManager : BaseManager
    {
        private ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public ResultModel GetAllCustomers(string token)
        {
            IList<Customer> listado = _customerRepository.GetAllCustomers();
            ResultModel resultModel = CheckToken(token);
            if (resultModel.Result)
            {
                resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(listado));
            }
            return resultModel;
        }

        public ResultModel GetCustomerById(int id, string token)
        {
            ResultModel resultModel = CheckToken(token);
            if (resultModel.Result)
            {
                Customer aCustomer = _customerRepository.GetCustomerById(id);
                resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(aCustomer));
            }
            return resultModel;
        }

        public void AddCustomer(Customer aCustomer)
        {
            _customerRepository.AddCustomer(aCustomer);
        }
    }
}
