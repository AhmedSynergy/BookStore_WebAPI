using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore_WebAPI.CoreFolder.Models;

namespace BookStore_WebAPI.InfrastructureFolder.Dtos
{
    public class OrderDetailsDTO
    {
        public OrderDetailsDTO()
        {
            this.OrderDetails = new OrderDetails();
        }
        public OrderDetails OrderDetails { get; set; }

        public OrderDetailsDTO ToOrderDetailDTO(OrderDetails orderDetails)
        {
            OrderDetails = orderDetails;
            return this;
        }

        public OrderDetails ToOrderDetails()
        {
            return OrderDetails;
        }

        
    }
}