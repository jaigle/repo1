using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using static System.Data.CommandType;
using System.Text;
using Dapper;
using Test.Entities;
using Test.Repository.Interfaces;

namespace Test.Repository
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public IList<Customer> GetAllCustomers()
        {
            IList<Customer> customerList = SqlMapper.Query<Customer>
                (con, "GetAllCustomers", commandType: StoredProcedure).ToList();
            return customerList;
        }

        public Customer GetCustomerById(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@id", id);
                return SqlMapper
                    .Query<Customer>(con, "GetCustomerById", parameters, commandType: StoredProcedure)
                    .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aCustomer"></param>
        public void AddCustomer(Customer aCustomer)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@FirstName", aCustomer.FirstName);
                parameters.Add("@LastName", aCustomer.LastName);
                parameters.Add("@City", aCustomer.City);
                parameters.Add("@Phone", aCustomer.Phone);
                parameters.Add("@Country", aCustomer.Country);
                SqlMapper.Query(con, "AddCustomer", parameters, commandType: StoredProcedure);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
