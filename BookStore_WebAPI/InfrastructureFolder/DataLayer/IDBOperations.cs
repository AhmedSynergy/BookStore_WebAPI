using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore_WebAPI.CoreFolder.Models;
using BookStore_WebAPI.InfrastructureFolder.Dtos;

namespace BookStore_WebAPI.InfrastructureFolder.DataLayer
{
    public interface IDBOperations
    {

        // customers
    
        IEnumerable<CustomerDTO> GetAllCustomers();

        int AddCustomer(CustomerDTO customer);



        // order and order details

        IEnumerable<OrderDTO> GetAllOrders();
        int AddOrder(OrderDTO order);

        OrderDTO GetOrder(int ID);




        int AddOrderDetails(OrderDetailsDTO orderDetail);

        IEnumerable<OrderDetailsDTO> GetOrderDetails(int OrderId);

        // books


        IEnumerable<BookDTO> GetAllBooks();

        int AddBook(BookDTO book);

        int EditBook(BookDTO book);

        int DeleteBook(int bookID);

        BookDTO GetMostExpensiveBook();

        IEnumerable<BookDTO> GetBooksByAuthor(string Name);

        IEnumerable<BookDTO> GetBooksByAuthorByMostExpensiveToLeast(string Name);






    }
}
