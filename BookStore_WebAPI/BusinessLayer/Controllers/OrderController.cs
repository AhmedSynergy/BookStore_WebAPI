using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BookStore_WebAPI.Models;
using System.Web.Http;
using System.Data.Entity;
using BookStore_WebAPI.DataLayer;

namespace BookStore_WebAPI.Controllers
{
    public class OrderController : ApiController
    {
        readonly DBOperations DBAccess = new DBOperations();
        // GET: Order
        public IEnumerable<Order> GetAllOrders()
        {
           
            return DBAccess.GetAllOrders();
        }

        public IHttpActionResult AddToCart(int OrderId, int BookId, int Quantity, int CustomerID)
        {
            var Order = DBAccess.GetOrder(OrderId);
            if(Order == null)
            {
                Order NewOrder = new Order();
                NewOrder.CustomerId = CustomerID;
                NewOrder.DateOfOrder = DateTime.Now;
                DBAccess.AddOrder(NewOrder);
                // make new order
            }
            OrderDetails NewOrderDetail = new OrderDetails();
            NewOrderDetail.OrderId = OrderId;
            NewOrderDetail.BookId = BookId;
            NewOrderDetail.Quantity = Quantity;
            int check = DBAccess.AddOrderDetails(NewOrderDetail);
            if (check == 1)
            {
                return Ok("Customer successfully added");

            }
            else
            {
                return NotFound();

            }

        }

        public IEnumerable<OrderDetails> GetOrderDetails(int OrderId)
        {
            return DBAccess.GetOrderDetails(OrderId);
        }

    }
}