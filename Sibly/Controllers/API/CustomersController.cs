using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using Sibly.Models;
using Sibly.ViewModels;
using System.Data.Entity;
//using System.Net.Http;

namespace Sibly.Controllers.API
{
    public class CustomersController : ApiController
    {
        public ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public IEnumerable<Customer> GetCustomers()
        {
            //Get /API/CUSTOMERS
            var customers = _context.Customers.ToList();
            return customers;
        }


        //Get /API/CUSTOMER
  
        public Customer GetCustomer(int id)
        {
            //Get /API/CUSTOMERS
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId==id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return customer;
        }


        //POST /API/CUSTOMER

        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
               throw new HttpResponseException(HttpStatusCode.BadRequest); 
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();
      
            return customer;
        }


        //PUT /API/CUSTOMER/1
  
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customerInDb = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customerInDb==null)
            {
               throw new HttpResponseException(HttpStatusCode.NotFound); 
            }
            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.isSubscribedToNewsletter = customer.isSubscribedToNewsletter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            _context.SaveChanges();

        }


        //DELETE /API/CUSTOMER

        public Customer CreateCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return customer;
        }




    }
}
