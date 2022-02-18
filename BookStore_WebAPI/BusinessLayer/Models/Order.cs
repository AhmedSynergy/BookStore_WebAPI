using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BookStore_WebAPI.Models
{

    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public int? CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        
        public string PaymentDetails { get; set; }

        public string DeliveryMethod { get; set; }

        public string DeliveryAddress { get; set; }
        
        public DateTime DateOfOrder { get; set; }
        public string OrderStatus { get; set; }

    }
}