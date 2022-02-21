using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore_WebAPI.CoreFolder.Models;

namespace BookStore_WebAPI.InfrastructureFolder.Dtos
{
    public class CustomerDTO
    {
        public Customer Customer { get; set; }

        public CustomerDTO ToCustomerDTO(Customer customer)
        {
            Customer = customer;
            return this;
        }

        public Customer ToCustomer()
        {
            return Customer;
        }

        
    }
}