using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace BookStore_WebAPI.CoreFolder.Models
{
    public class OrderDetails
    {
            [Key]
            public int OrderDetailsId { get; set; }

            public int? BookId { get; set; }

            [ForeignKey("BookId")]
            public virtual Book Book { get; set; }
            public int? OrderId { get; set; }

            [ForeignKey("OrderId")]
            public virtual Order Order { get; set; }

            public int Quantity { get; set; }


        
    }
}