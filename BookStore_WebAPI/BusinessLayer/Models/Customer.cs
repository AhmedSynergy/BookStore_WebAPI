using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore_WebAPI.Models
{
    public class Customer
    {
        public int CustomerId { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
    }
}