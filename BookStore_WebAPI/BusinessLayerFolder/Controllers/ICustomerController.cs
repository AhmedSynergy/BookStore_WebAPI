﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using BookStore_WebAPI.InfrastructureFolder.Dtos;

namespace BookStore_WebAPI.BusinessLayerFolder.Controllers
{
    interface ICustomerController
    {
        
        IEnumerable<CustomerDTO> GetAllCustomers();

        IHttpActionResult LoginCustomer(string email, string password);

        IHttpActionResult CustomerRegistration(CustomerDTO customer);


    }
}