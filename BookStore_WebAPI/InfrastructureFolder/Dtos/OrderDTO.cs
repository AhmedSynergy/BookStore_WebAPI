using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore_WebAPI.CoreFolder.Models;

namespace BookStore_WebAPI.InfrastructureFolder.Dtos
{
    public class OrderDTO
    {
        public Order Order { get; set; }

        public OrderDTO ToOrderDTO(Order order)
        {
            Order = order;
            return this;
        }

        public Order ToOrder()
        {
            return Order;
        }

        
    }
}