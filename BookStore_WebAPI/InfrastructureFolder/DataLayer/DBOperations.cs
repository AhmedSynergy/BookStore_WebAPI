using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using BookStore_WebAPI.CoreFolder.Dtos;
using PagedList;
using System.Data.Entity;
using BookStore_WebAPI.InfrastructureFolder.DataLayer;
using BookStore_WebAPI.CoreFolder.Models;

namespace BookStore_WebAPI.InfrastructureFolder.DataLayer
{
    public class DBOperations
    {
        ShopDBContext Database = new ShopDBContext();


        // Customer
        public IEnumerable<Customer> GetAllCustomers()
        {
            var data = Database.Customers.ToList();
            return data;
        }

        public int AddCustomer(Customer customer)
        {
            Database.Customers.Add(customer);
            return Database.SaveChanges();

        }



        // Order and Order Details

        public IEnumerable<Order> GetAllOrders()
        {
            return Database.Orders.ToList();

        }

        public int AddOrder(Order order)
        {
            Database.Orders.Add(order);
            return Database.SaveChanges();

        }

        public Order GetOrder(int ID)
        {
            return Database.Orders.Where(order => order.OrderId == ID).SingleOrDefault();
        }

        public int AddOrderDetails(OrderDetails orderDetail)
        {
            Database.OrderDetails.Add(orderDetail);
            return Database.SaveChanges();

        }

        public IEnumerable<OrderDetails> GetOrderDetails(int OrderId)
        {
            return Database.OrderDetails.Where(orderDetail => orderDetail.OrderId == OrderId).ToList();

        }

        private IEnumerable<BookIDandQuantity> GetOrderDetailsGroupedByQuantity()
        {
            var orderDetails = from orderDetail in Database.OrderDetails select orderDetail;
            var orderDetailsGrouped = from orderDetail in orderDetails
                                      group orderDetail by orderDetail.BookId into orderDetailGrouped
                                      select new BookIDandQuantity { BookId = orderDetailGrouped.Key.Value, Quantity = orderDetailGrouped.Sum(y => y.Quantity) };

            return orderDetailsGrouped;
        }


        // Books

        public IEnumerable<Book> GetAllBooks()
        {
            var data = Database.Books.ToList();
            return data;
        }

        public int AddBook(Book book)
        {
            Database.Books.Add(book);
            return Database.SaveChanges();
        }
        public int EditBook(Book book)
        {
            Database.Entry(book).State = System.Data.Entity.EntityState.Modified;
            return Database.SaveChanges();
        }
        
        public int DeleteBook(int bookID)
        {
            Database.Entry(Database.Books.Where(book => book.Id == bookID).FirstOrDefault()).State = System.Data.Entity.EntityState.Deleted;
            return Database.SaveChanges();
        }

        public Book GetMostExpensiveBook()
        {

            var book = Database.Books.ToList().OrderByDescending(b => b.Price).FirstOrDefault();
            return book;

        }

        public IEnumerable<Book> GetBooksByAuthor(string Name)
        {
            return Database.Books.Where(book => book.Author.Contains(Name))
                .DefaultIfEmpty();
        }
        public IEnumerable<Book> GetBooksByAuthorByMostExpensiveToLeast(string Name)
        {
            return Database.Books.Where(book => book.Author.Contains(Name))
                .OrderByDescending(book => book.Price);
        }


        // Order details and books - join


        public IEnumerable<BooksAndOrderQuantityDTO> GetBooksByAuthorByMostOrderedToLeast(string authorName)
        {
            var books = this.GetBooksByAuthor(authorName);

            var orderDetailsGrouped = this.GetOrderDetailsGroupedByQuantity();

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


    }

}