using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using BookStore_WebAPI.CoreFolder.Models;
using BookStore_WebAPI.CoreFolder.Dtos;
using PagedList;
using System.Data.Entity;
using BookStore_WebAPI.InfrastructureFolder.DataLayer;

namespace BookStore.Controllers
{
    public class BookController : ApiController
    {
        readonly DBOperations DBAccess = new DBOperations();


        // GET: list of books
        public IEnumerable<Book> GetAllBooks(int page, int ItemsPerPage)
        {
            PagingParameterModel PageNumber = new PagingParameterModel
            {
                Page = page,
                ItemsPerPage = ItemsPerPage
            };

            var books = DBAccess.GetAllBooks();
            books = books.OrderBy(book => book.Id)
                .Skip((PageNumber.Page - 1) * PageNumber.ItemsPerPage)
                .Take(PageNumber.ItemsPerPage);

       //     System.Diagnostics.Debug.WriteLine(books);




            return books;


        }


        // GET: most expensive  book

        public Book GetMostExpensiveBook()
        {
            return DBAccess.GetMostExpensiveBook();
        }


        public IEnumerable<Book> GetBooksByAuthor(string authorName)
        {
            return DBAccess.GetBooksByAuthor(authorName);
        }

        public IEnumerable<Book> GetBooksByAuthorByMostExpensiveToLeast(string authorName)
        {
            return DBAccess.GetBooksByAuthorByMostExpensiveToLeast(authorName);
            
        }

         public IEnumerable<BooksAndOrderQuantityDTO> GetBooksByAuthorByMostOrderedToLeast(string authorName)
      {

            return DBAccess.GetBooksByAuthorByMostOrderedToLeast(authorName);

        }

        public string Create(Book book)
        {
            if (ModelState.IsValid)
            {
                int check = DBAccess.AddBook(book);

                if (check == 1)
                {
                    return "Data Inserted Successfully";

                }
                else
                {
                    return "Data insertion failed";

                }
            }

            return "Data insertion failed";
        }


        // EDIT
        public IHttpActionResult EditBook(Book book)
        {
            if (ModelState.IsValid == true)
            {
                int check = DBAccess.EditBook(book);

                if (check == 1)
                {
                    return Ok("Successfully updated");

                }
                else
                {
                    return NotFound();

                }
            }
            return BadRequest("Not a valid model.");

        }


        public IHttpActionResult DeleteBook(int bookID)
        {
            int check = DBAccess.DeleteBook(bookID);
            if (check == 1)
            {
                if (check == 1)
                {
                    return Ok("Successfully deleted");

                }
                else
                {
                    return NotFound();

                }
            }
            return BadRequest("Not a valid model");

        }

    }
}