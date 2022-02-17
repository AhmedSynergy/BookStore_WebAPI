using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using BookStore_WebAPI.Models;
using BookStore_WebAPI.Dtos;
using PagedList;
using System.Data.Entity;

namespace BookStore.Controllers
{
    public class BookController : ApiController
    {
        ShopContext database = new ShopContext();

        // GET: list of books
        public IEnumerable<Book> GetAllBooks(int page, int ItemsPerPage)
        {
            PagingParameterModel PageNumber = new PagingParameterModel
            {
                Page = page,
                ItemsPerPage = ItemsPerPage
            };


            var books = database.Books.OrderBy(book => book.Id)
                .Skip((PageNumber.Page - 1) * PageNumber.ItemsPerPage)
                .Take(PageNumber.ItemsPerPage)
                .ToList();

       //     System.Diagnostics.Debug.WriteLine(books);




            return books;


        }


        // GET: most expensive  book

        public Book GetMostExpensiveBook()
        {
            var books = database.Books.ToList().OrderByDescending(book => book.Price);


            return books.ElementAt(0);
        }


        public IEnumerable<Book> GetBooksByAuthor(string authorName)
        {
            var books = from book in database.Books select book;
            if (!String.IsNullOrEmpty(authorName))
            {
                books = books.Where(book => book.Author.Contains(authorName));
            }

            return books;
        }

        public IEnumerable<Book> GetBooksByAuthorByMostExpensiveToLeast(string authorName)
        {
            var books = from book in database.Books select book;
            if (!String.IsNullOrEmpty(authorName))
            {
                books = books.Where(book => book.Author.Contains(authorName)).OrderByDescending(book => book.Price);
            }

            return books;
        }

         public IEnumerable<BooksAndOrderQuantityDTO> GetBooksByAuthorByMostOrderedToLeast(string authorName)
      {
            var books = from book in database.Books select book;
            books = books.Where(book => book.Author.Contains(authorName));
            var orderDetails = from orderDetail in database.OrderDetails select orderDetail;

            var orderDetailsGrouped = from orderDetail in orderDetails
                    group orderDetail by orderDetail.BookId into orderDetailGrouped
                                      select new BookIDandQuantity{BookId = orderDetailGrouped.Key.Value, Quantity = orderDetailGrouped.Sum(y => y.Quantity) };
            


            if (!String.IsNullOrEmpty(authorName))
            {

                var booksOrdered = books
                    .Join(
                    orderDetailsGrouped,
                    book => book.Id,
                    orderDetail => orderDetail.BookId,
                    (book, orderDetail) => new BooksAndOrderQuantityDTO
                    {
                        Book = book,
                        Quantity = orderDetail.Quantity
                    }
                    )
                   .OrderByDescending(book => book.Quantity);

     
               return booksOrdered;

            }

            else
            {
                books = null;
                return null;
            }

        }

        public string Create(Book book)
        {
            if (ModelState.IsValid)
            {
                database.Books.Add(book);
                int check = database.SaveChanges();

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
                database.Entry(book).State = System.Data.Entity.EntityState.Modified;
                int check = database.SaveChanges();

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
            database.Entry(database.Books.Where(book => book.Id == bookID).FirstOrDefault()).State = System.Data.Entity.EntityState.Deleted;
            int check = database.SaveChanges();
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