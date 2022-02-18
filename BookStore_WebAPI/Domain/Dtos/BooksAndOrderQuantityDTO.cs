using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore_WebAPI.Models;

namespace BookStore_WebAPI.Dtos
{
    public class BooksAndOrderQuantityDTO
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}