using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore_WebAPI.CoreFolder.Models;

namespace BookStore_WebAPI.InfrastructureFolder.DataLayer
{
    public class BookIDandQuantity
    {
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}