using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore_WebAPI.CoreFolder.Models;

namespace BookStore_WebAPI.InfrastructureFolder.Dtos
{
    public class BookDTO
    {
        public Book Book { get; set; }

        public BookDTO ToBookDTO(Book book)
        {
            Book = book;
            return this;
        }

        public Book ToBook()
        {
            return Book;
        }

        
    }
}