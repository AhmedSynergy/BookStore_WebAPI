using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BookStore_WebAPI.Models;
using BookStore_WebAPI.DataLayer;

namespace BookStore.Controllers
{
    public class CustomerController : ApiController
    {
        readonly DBOperations DBAccess = new DBOperations();
        // GET: Customer
        public IEnumerable<Customer> GetAllCustomers()
        {
            return DBAccess.GetAllCustomers();
        }


        public IHttpActionResult CustomerRegistration(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var customers = DBAccess.GetAllCustomers();
                foreach ( Customer cust in customers)
                {
                    if (cust.Email == customer.Email)
                        return Ok("Email already in use");
                }




                if (customer.Password.Length < 6) // length > = 6
                    return Ok("Length of password should be atleast 6.");

                int check = DBAccess.AddCustomer(customer);
                if (check == 1)
                {
                    return Ok("Customer successfully added");

                }
                else
                {
                    return NotFound();

                }
            }
        
             return BadRequest("Not a valid model.");

        }
        
        
        public IHttpActionResult LoginCustomer(string email,string password)
        {
            if (ModelState.IsValid)
            {
                var customers = DBAccess.GetAllCustomers();
                foreach ( Customer cust in customers)
                {
                    if (cust.Email == email && cust.Password == password)
                        return Ok("Login Successful.");
                    else if (cust.Email == email)
                        return BadRequest("Invalid password");
                }
            }
        
             return BadRequest("Invalid input");

        }
    }
}