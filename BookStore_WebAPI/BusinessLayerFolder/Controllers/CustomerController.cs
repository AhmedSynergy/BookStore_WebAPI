using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BookStore_WebAPI.BusinessLayerFolder.Controllers;

using BookStore_WebAPI.InfrastructureFolder.DataLayer;
using BookStore_WebAPI.InfrastructureFolder.Dtos;

namespace BookStore.Controllers
{
    public class CustomerController : ApiController,ICustomerController
    {
        readonly DBOperations DBAccess = new DBOperations();
















        //
        // GET: Customer
        public IEnumerable<CustomerDTO> GetAllCustomers()
        {
            return DBAccess.GetAllCustomers();
        }


        public IHttpActionResult CustomerRegistration(CustomerDTO customer)
        {
            if (ModelState.IsValid)
            {
                var customers = DBAccess.GetAllCustomers();
                foreach ( CustomerDTO cust in customers)
                {
                    if (cust.Customer.Email == customer.Customer.Email)
                        return Ok("Email already in use");
                }




                if (customer.Customer.Password.Length < 6) // length > = 6
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
                foreach ( CustomerDTO cust in customers)
                {
                    if (cust.Customer.Email == email && cust.Customer.Password == password)
                        return Ok("Login Successful.");
                    else if (cust.Customer.Email == email)
                        return BadRequest("Invalid password");
                }
            }
        
             return BadRequest("Invalid input");

        }
      

        
    }
}