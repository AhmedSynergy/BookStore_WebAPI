using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BookStore_WebAPI.Models;
using System.Web.Http;
using System.Data.Entity;
namespace BookStore_WebAPI.Controllers
{
    public class OrderController : ApiController
    {
        ShopContext database = new ShopContext();
        // GET: Order
        public IEnumerable<Order> GetAllOrders()
        {
            var data = database.Orders.ToList();
            return data;
        }

        public void AddToCart(int OrderId, int BookId, int Quantity, int CustomerID)
        {
            var Order = database.Orders.Where(order => order.OrderId==OrderId).SingleOrDefault();
            if(Order == null)
            {
                Order NewOrder = new Order();
                NewOrder.CustomerId = CustomerID;
                NewOrder.DateOfOrder = DateTime.Now;
                // make new order
            }
            OrderDetails NewOrderDetail = new OrderDetails();
            NewOrderDetail.OrderId = OrderId;
            NewOrderDetail.BookId = BookId;
            NewOrderDetail.Quantity = Quantity;
            database.OrderDetails.Add(NewOrderDetail);
            database.SaveChanges();

        }

        public IEnumerable<OrderDetails> GetOrderDetails(int OrderId)
        {
            var OrderDetails = database.OrderDetails.Where(orderDetail => orderDetail.OrderId == OrderId).ToList();

            return OrderDetails;


        }

    }
}