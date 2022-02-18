using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BookStore_WebAPI.CoreFolder.Models;

namespace BookStore_WebAPI.InfrastructureFolder.DataLayer
{
    public class ShopDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

    }
}