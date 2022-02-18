using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore_WebAPI.CoreFolder.Models;

namespace BookStore_WebAPI.CoreFolder.Dtos
{
    public class BooksAndOrderQuantityDTO
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}