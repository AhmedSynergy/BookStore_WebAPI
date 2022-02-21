using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Http;
using System.Data.Entity;
using BookStore_WebAPI.InfrastructureFolder.DataLayer;
using BookStore_WebAPI.InfrastructureFolder.Dtos;

namespace BookStore_WebAPI.BusinessLayerFolder.Controllers
{
    public class OrderController : ApiController,IOrderController
    {
        readonly DBOperations DBAccess = new DBOperations();
        // GET: Order
        public IEnumerable<OrderDTO> GetAllOrders()
        {
           
            return DBAccess.GetAllOrders();
        }

        public IHttpActionResult AddToCart(int OrderId, int BookId, int Quantity, int CustomerID)
        {
            var Order = DBAccess.GetOrder(OrderId);
            if(Order == null)
            {
                OrderDTO NewOrder = new OrderDTO();
                NewOrder.Order.CustomerId = CustomerID;
                NewOrder.Order.DateOfOrder = DateTime.Now;
                DBAccess.AddOrder(NewOrder);
                // make new order
            }
            OrderDetailsDTO NewOrderDetail = new OrderDetailsDTO();
            NewOrderDetail.OrderDetails.OrderId = OrderId;
            NewOrderDetail.OrderDetails.BookId = BookId;
            NewOrderDetail.OrderDetails.Quantity = Quantity;
            int check = DBAccess.AddOrderDetails(NewOrderDetail);
            if (check == 1)
            {
                return Ok("Added to cart successfully");

            }
            else
            {
                return NotFound();

            }

        }

        public IEnumerable<OrderDetailsDTO> GetOrderDetails(int OrderId)
        {
            return DBAccess.GetOrderDetails(OrderId);
        }

    }
}