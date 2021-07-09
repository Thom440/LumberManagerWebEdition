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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.EnableSensitiveDataLogging();
        //}

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderLineItems> OrderLineItems { get; set; }
        public virtual DbSet<User> Customers { get; set; }

        /// <summary>
        /// Setting keys for the order line items and entering seed data for categories.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<OrderLineItems>().HasKey(OrderLineItems => new { OrderLineItems.OrderID, OrderLineItems.ProductID });

            Category WW = new Category { CategoryID = 1, CategoryName = "WW" };
            Category TwoFive = new Category { CategoryID = 2, CategoryName = ".25" };
            Category FourO = new Category { CategoryID = 3, CategoryName = ".40" };
            Category SixO = new Category { CategoryID = 4, CategoryName = ".60" };
            Category ACQ = new Category { CategoryID = 5, CategoryName = "ACQ" };
            Category CCA = new Category { CategoryID = 6, CategoryName = "CCA" };
            Category NA = new Category { CategoryID = 7, CategoryName = "N/A" };

            builder.Entity<Category>().HasData(WW);
            builder.Entity<Category>().HasData(TwoFive);
            builder.Entity<Category>().HasData(FourO);
            builder.Entity<Category>().HasData(SixO);
            builder.Entity<Category>().HasData(ACQ);
            builder.Entity<Category>().HasData(CCA);
            builder.Entity<Category>().HasData(NA);

            builder.Entity<Product>().HasData(new Product { ProductID = 1, Height = 2, Width = 4, Length = 8, BoardFeet = 1109, Category = new List<Category>() { WW, NA } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 2, Height = 2, Width = 4, Length = 10, BoardFeet = 1387, Category = new List<Category>() { WW, NA } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 3, Height = 2, Width = 4, Length = 12, BoardFeet = 1664, Category = new List<Category>() { WW, NA } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 4, Height = 2, Width = 4, Length = 14, BoardFeet = 1941, Category = new List<Category>() { WW, NA } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 5, Height = 2, Width = 4, Length = 16, BoardFeet = 2219, Category = new List<Category>() { WW, NA } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 6, Height = 2, Width = 4, Length = 18, BoardFeet = 2496, Category = new List<Category>() { WW, NA } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 7, Height = 2, Width = 4, Length = 20, BoardFeet = 2773, Category = new List<Category>() { WW, NA } });

            //builder.Entity<Product>().HasData(new Product { ProductID = 8, Height = 2, Width = 4, Length = 8, BoardFeet = 1109, Category = new List<Category>() { TwoFive, ACQ } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 9, Height = 2, Width = 4, Length = 10, BoardFeet = 1387, Category = new List<Category>() { TwoFive, ACQ } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 10, Height = 2, Width = 4, Length = 12, BoardFeet = 1664, Category = new List<Category>() { TwoFive, ACQ } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 11, Height = 2, Width = 4, Length = 14, BoardFeet = 1941, Category = new List<Category>() { TwoFive, ACQ } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 12, Height = 2, Width = 4, Length = 16, BoardFeet = 2219, Category = new List<Category>() { TwoFive, ACQ } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 13, Height = 2, Width = 4, Length = 18, BoardFeet = 2496, Category = new List<Category>() { TwoFive, ACQ } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 14, Height = 2, Width = 4, Length = 20, BoardFeet = 2773, Category = new List<Category>() { TwoFive, ACQ } });

            //builder.Entity<Product>().HasData(new Product { ProductID = 15, Height = 2, Width = 4, Length = 8, BoardFeet = 1109, Category = new List<Category>() { FourO, ACQ } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 16, Height = 2, Width = 4, Length = 10, BoardFeet = 1387, Category = new List<Category>() { FourO, ACQ } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 17, Height = 2, Width = 4, Length = 12, BoardFeet = 1664, Category = new List<Category>() { FourO, ACQ } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 18, Height = 2, Width = 4, Length = 14, BoardFeet = 1941, Category = new List<Category>() { FourO, ACQ } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 19, Height = 2, Width = 4, Length = 16, BoardFeet = 2219, Category = new List<Category>() { FourO, ACQ } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 20, Height = 2, Width = 4, Length = 18, BoardFeet = 2496, Category = new List<Category>() { FourO, ACQ } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 21, Height = 2, Width = 4, Length = 20, BoardFeet = 2773, Category = new List<Category>() { FourO, ACQ } });

            //builder.Entity<Product>().HasData(new Product { ProductID = 22, Height = 2, Width = 4, Length = 8, BoardFeet = 1109, Category = new List<Category>() { TwoFive, CCA } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 23, Height = 2, Width = 4, Length = 10, BoardFeet = 1387, Category = new List<Category>() { TwoFive, CCA } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 24, Height = 2, Width = 4, Length = 12, BoardFeet = 1664, Category = new List<Category>() { TwoFive, CCA } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 25, Height = 2, Width = 4, Length = 14, BoardFeet = 1941, Category = new List<Category>() { TwoFive, CCA } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 26, Height = 2, Width = 4, Length = 16, BoardFeet = 2219, Category = new List<Category>() { TwoFive, CCA } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 27, Height = 2, Width = 4, Length = 18, BoardFeet = 2496, Category = new List<Category>() { TwoFive, CCA } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 28, Height = 2, Width = 4, Length = 20, BoardFeet = 2773, Category = new List<Category>() { TwoFive, CCA } });

            //builder.Entity<Product>().HasData(new Product { ProductID = 29, Height = 2, Width = 4, Length = 8, BoardFeet = 1109, Category = new List<Category>() { SixO, CCA } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 30, Height = 2, Width = 4, Length = 10, BoardFeet = 1387, Category = new List<Category>() { SixO, CCA } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 31, Height = 2, Width = 4, Length = 12, BoardFeet = 1664, Category = new List<Category>() { SixO, CCA } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 32, Height = 2, Width = 4, Length = 14, BoardFeet = 1941, Category = new List<Category>() { SixO, CCA } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 33, Height = 2, Width = 4, Length = 16, BoardFeet = 2219, Category = new List<Category>() { SixO, CCA } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 34, Height = 2, Width = 4, Length = 18, BoardFeet = 2496, Category = new List<Category>() { SixO, CCA } });
            //builder.Entity<Product>().HasData(new Product { ProductID = 35, Height = 2, Width = 4, Length = 20, BoardFeet = 2773, Category = new List<Category>() { SixO, CCA } });
        }
    }
}
