using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using BookStore_WebAPI.InfrastructureFolder.Dtos;
using PagedList;
using System.Data.Entity;
using BookStore_WebAPI.InfrastructureFolder.DataLayer;
using BookStore_WebAPI.CoreFolder.Models;

namespace BookStore_WebAPI.InfrastructureFolder.DataLayer
{
    public class DBOperations : IDBOperations
    {
        ShopDBContext Database = new ShopDBContext();




        //TEST

        

        // Customer

        public IEnumerable<CustomerDTO> GetAllCustomers()
        {
            
            var data = Database.Customers.ToList();
            List<CustomerDTO> customers = new List<CustomerDTO>();

            foreach (Customer customer in data)
            {
                customers.Add(new CustomerDTO().ToCustomerDTO(customer));
            }

            
            return customers;
        }

        public int AddCustomer(CustomerDTO customer)
        {
            Database.Customers.Add(customer.ToCustomer());
            return Database.SaveChanges();

        }



        // Order and Order Details

        public IEnumerable<OrderDTO> GetAllOrders()
        {
            var data = Database.Orders.ToList();
            List<OrderDTO> orders = new List<OrderDTO>();

            foreach (Order order in data)
            {
                orders.Add(new OrderDTO().ToOrderDTO(order));
            }


            return orders;

        }

        public int AddOrder(OrderDTO order)
        {
            Database.Orders.Add(order.ToOrder());
            return Database.SaveChanges();

        }

        public OrderDTO GetOrder(int ID)
        {
            var data = Database.Orders.Where(order => order.OrderId == ID).SingleOrDefault();
            OrderDTO Order = new OrderDTO
            {
                Order = data
            };

            return Order;

        }


        public int AddOrderDetails(OrderDetailsDTO orderDetail)
        {
            Database.OrderDetails.Add(orderDetail.OrderDetails);
            return Database.SaveChanges();

        }

        public IEnumerable<OrderDetailsDTO> GetOrderDetails(int OrderId)
        {
            var data = Database.OrderDetails.Where(orderDetail => orderDetail.OrderId == OrderId).ToList();


            List<OrderDetailsDTO> OrderDetailsDTO = new List<OrderDetailsDTO>();

            foreach(OrderDetails orderDetails in data)
            {
                OrderDetailsDTO.Add(new OrderDetailsDTO{
                    OrderDetails = orderDetails 
                });
            }

            return OrderDetailsDTO;

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

        public IEnumerable<BookDTO> GetAllBooks()
        {

            var data = Database.Books.ToList();
            List<BookDTO> books = new List<BookDTO>();

            foreach (Book book in data)
            {
                books.Add(new BookDTO().ToBookDTO(book));
            }
            return books;

        }

        public int AddBook(BookDTO book)
        {
            Database.Books.Add(book.ToBook());
            return Database.SaveChanges();
        }
        public int EditBook(BookDTO book)
        {
            Database.Entry(book.ToBook()).State = System.Data.Entity.EntityState.Modified;
            return Database.SaveChanges();
        }
        
        public int DeleteBook(int bookID)
        {
            Database.Entry(Database.Books.Where(book => book.Id == bookID).FirstOrDefault()).State = System.Data.Entity.EntityState.Deleted;
            return Database.SaveChanges();
        }

        public BookDTO GetMostExpensiveBook()
        {

            var book = Database.Books.ToList().OrderByDescending(b => b.Price).FirstOrDefault();
            return new BookDTO
            {
                Book = book 
            };

        }

        public IEnumerable<BookDTO> GetBooksByAuthor(string Name)
        {
            var data = Database.Books.Where(book => book.Author.Contains(Name))
                .DefaultIfEmpty();

            List<BookDTO> books = new List<BookDTO>();

            foreach (Book book in data)
            {
                books.Add(new BookDTO().ToBookDTO(book));
            }

            return books;
        }


        public IEnumerable<BookDTO> GetBooksByAuthorByMostExpensiveToLeast(string Name)
        {


            var data =  Database.Books.Where(book => book.Author.Contains(Name))
                .OrderByDescending(book => book.Price);

            List<BookDTO> books = new List<BookDTO>();

            foreach (Book book in data)
            {
                books.Add(new BookDTO().ToBookDTO(book));
            }

            return books;

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
                    book => book.Book.Id,
                    orderDetail => orderDetail.BookId,
                    (book, orderDetail) => new BooksAndOrderQuantityDTO
                    {
                        Book = book.Book,
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