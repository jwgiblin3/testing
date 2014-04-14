using AngualrJSWebAPIApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngualrJSWebAPIApp
{
    public class CustomerController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Customer> Get()
        {
            CustomerContext customersdb = new CustomerContext();
            return customersdb.Customers;
        }

       // POST api/<controller>
        public void Post([FromBody]Customer customer)
        {
            CustomerContext customersdb = new CustomerContext();
            customersdb.Customers.Add(customer);
            customersdb.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Customer customer)
        {
            CustomerContext customersdb = new CustomerContext();
            Customer customerToRemove=customersdb.Customers.Find(customer.id);
           
            customersdb.Customers.Remove(customerToRemove);
            Customer updatedCustomer = customer;
            customersdb.Customers.Add(updatedCustomer);

            customersdb.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(string id)
        {
            CustomerContext customersdb = new CustomerContext();
            Customer cust=customersdb.Customers.Find(id);
            customersdb.Customers.Remove(cust);
            customersdb.SaveChanges();
        }
    }
}