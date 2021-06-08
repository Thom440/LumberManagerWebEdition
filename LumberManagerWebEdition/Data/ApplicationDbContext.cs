using LumberManagerWebEdition.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LumberManagerWebEdition.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderLineItems> OrderLineItems { get; set; }

        /// <summary>
        /// Setting keys for the order line items and entering seed data for categories.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<OrderLineItems>().HasKey(OrderLineItems => new { OrderLineItems.OrderID, OrderLineItems.ProductID });

            builder.Entity<Category>().HasData(new Category { CategoryID = 1, CategoryName = "WW" });
            builder.Entity<Category>().HasData(new Category { CategoryID = 2, CategoryName = ".25" });
            builder.Entity<Category>().HasData(new Category { CategoryID = 3, CategoryName = ".40" });
            builder.Entity<Category>().HasData(new Category { CategoryID = 4, CategoryName = ".60" });
            builder.Entity<Category>().HasData(new Category { CategoryID = 5, CategoryName = "ACQ" });
            builder.Entity<Category>().HasData(new Category { CategoryID = 6, CategoryName = "CCA" });
            builder.Entity<Category>().HasData(new Category { CategoryID = 7, CategoryName = "N/A" });
        }
        public virtual DbSet<User> Customers { get; set; }
    }
}
