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

            builder.Entity<Product>().HasData(new Product { ProductID = 1, Height = 2, Width = 4, Length = 8, BoardFeet = 1109 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 1 },new { CategoryID = 7, ProductsProductID = 1 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 2, Height = 2, Width = 4, Length = 10, BoardFeet = 1387 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 2 }, new { CategoryID = 7, ProductsProductID = 2 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 3, Height = 2, Width = 4, Length = 12, BoardFeet = 1664 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 3 }, new { CategoryID = 7, ProductsProductID = 3 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 4, Height = 2, Width = 4, Length = 14, BoardFeet = 1941 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 4 }, new { CategoryID = 7, ProductsProductID = 4 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 5, Height = 2, Width = 4, Length = 16, BoardFeet = 2219 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 5 }, new { CategoryID = 7, ProductsProductID = 5 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 6, Height = 2, Width = 4, Length = 18, BoardFeet = 2496 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 6 }, new { CategoryID = 7, ProductsProductID = 6 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 7, Height = 2, Width = 4, Length = 20, BoardFeet = 2773 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 7 }, new { CategoryID = 7, ProductsProductID = 7 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 8, Height = 2, Width = 6, Length = 8, BoardFeet = 1024 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 8 }, new { CategoryID = 7, ProductsProductID = 8 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 9, Height = 2, Width = 6, Length = 10, BoardFeet = 1280 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 9 }, new { CategoryID = 7, ProductsProductID = 9 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 10, Height = 2, Width = 6, Length = 12, BoardFeet = 1536 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 10 }, new { CategoryID = 7, ProductsProductID = 10 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 11, Height = 2, Width = 6, Length = 14, BoardFeet = 1792 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 11 }, new { CategoryID = 7, ProductsProductID = 11 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 12, Height = 2, Width = 6, Length = 16, BoardFeet = 2048 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 12 }, new { CategoryID = 7, ProductsProductID = 12 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 13, Height = 2, Width = 6, Length = 18, BoardFeet = 2304 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 13 }, new { CategoryID = 7, ProductsProductID = 13 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 14, Height = 2, Width = 6, Length = 20, BoardFeet = 2560 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 14 }, new { CategoryID = 7, ProductsProductID = 14 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 15, Height = 2, Width = 8, Length = 8, BoardFeet = 1024 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 15 }, new { CategoryID = 7, ProductsProductID = 15 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 16, Height = 2, Width = 8, Length = 10, BoardFeet = 1280 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 16 }, new { CategoryID = 7, ProductsProductID = 16 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 17, Height = 2, Width = 8, Length = 12, BoardFeet = 1536 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 17 }, new { CategoryID = 7, ProductsProductID = 17 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 18, Height = 2, Width = 8, Length = 14, BoardFeet = 1792 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 18 }, new { CategoryID = 7, ProductsProductID = 18 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 19, Height = 2, Width = 8, Length = 16, BoardFeet = 2048 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 19 }, new { CategoryID = 7, ProductsProductID = 19 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 20, Height = 2, Width = 8, Length = 18, BoardFeet = 2304 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 20 }, new { CategoryID = 7, ProductsProductID = 20 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 21, Height = 2, Width = 8, Length = 20, BoardFeet = 2560 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 21 }, new { CategoryID = 7, ProductsProductID = 21 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 22, Height = 2, Width = 10, Length = 8, BoardFeet = 1067 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 22 }, new { CategoryID = 7, ProductsProductID = 22 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 23, Height = 2, Width = 10, Length = 10, BoardFeet = 1333 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 23 }, new { CategoryID = 7, ProductsProductID = 23 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 24, Height = 2, Width = 10, Length = 12, BoardFeet = 1600 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 24 }, new { CategoryID = 7, ProductsProductID = 24 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 25, Height = 2, Width = 10, Length = 14, BoardFeet = 1867 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 25 }, new { CategoryID = 7, ProductsProductID = 25 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 26, Height = 2, Width = 10, Length = 16, BoardFeet = 2133 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 26 }, new { CategoryID = 7, ProductsProductID = 26 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 27, Height = 2, Width = 10, Length = 18, BoardFeet = 2400 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 27 }, new { CategoryID = 7, ProductsProductID = 27 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 28, Height = 2, Width = 10, Length = 20, BoardFeet = 2667 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 28 }, new { CategoryID = 7, ProductsProductID = 28 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 29, Height = 2, Width = 12, Length = 8, BoardFeet = 1024 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 29 }, new { CategoryID = 7, ProductsProductID = 29 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 30, Height = 2, Width = 12, Length = 10, BoardFeet = 1280 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 30 }, new { CategoryID = 7, ProductsProductID = 30 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 31, Height = 2, Width = 12, Length = 12, BoardFeet = 1536 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 31 }, new { CategoryID = 7, ProductsProductID = 31 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 32, Height = 2, Width = 12, Length = 14, BoardFeet = 1792 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 32 }, new { CategoryID = 7, ProductsProductID = 32 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 33, Height = 2, Width = 12, Length = 16, BoardFeet = 2048 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 33 }, new { CategoryID = 7, ProductsProductID = 33 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 34, Height = 2, Width = 12, Length = 18, BoardFeet = 2304 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 34 }, new { CategoryID = 7, ProductsProductID = 34 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 35, Height = 2, Width = 12, Length = 20, BoardFeet = 2560 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 35 }, new { CategoryID = 7, ProductsProductID = 35 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 36, Height = 3, Width = 4, Length = 8, BoardFeet = 936 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 36 }, new { CategoryID = 7, ProductsProductID = 36 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 37, Height = 3, Width = 4, Length = 10, BoardFeet = 1170 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 37 }, new { CategoryID = 7, ProductsProductID = 37 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 38, Height = 3, Width = 4, Length = 12, BoardFeet = 1404 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 38 }, new { CategoryID = 7, ProductsProductID = 38 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 39, Height = 3, Width = 4, Length = 14, BoardFeet = 1638 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 39 }, new { CategoryID = 7, ProductsProductID = 39 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 40, Height = 3, Width = 4, Length = 16, BoardFeet = 1872 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 40 }, new { CategoryID = 7, ProductsProductID = 40 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 41, Height = 3, Width = 4, Length = 18, BoardFeet = 2106 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 41 }, new { CategoryID = 7, ProductsProductID = 41 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 42, Height = 3, Width = 4, Length = 20, BoardFeet = 2340 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 42 }, new { CategoryID = 7, ProductsProductID = 42 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 43, Height = 3, Width = 6, Length = 8, BoardFeet = 864 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 43 }, new { CategoryID = 7, ProductsProductID = 43 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 44, Height = 3, Width = 6, Length = 10, BoardFeet = 1080 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 44 }, new { CategoryID = 7, ProductsProductID = 44 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 45, Height = 3, Width = 6, Length = 12, BoardFeet = 1296 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 45 }, new { CategoryID = 7, ProductsProductID = 45 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 46, Height = 3, Width = 6, Length = 14, BoardFeet = 1512 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 46 }, new { CategoryID = 7, ProductsProductID = 46 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 47, Height = 3, Width = 6, Length = 16, BoardFeet = 1728 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 47 }, new { CategoryID = 7, ProductsProductID = 47 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 48, Height = 3, Width = 6, Length = 18, BoardFeet = 1944 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 48 }, new { CategoryID = 7, ProductsProductID = 48 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 49, Height = 3, Width = 6, Length = 20, BoardFeet = 2160 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 49 }, new { CategoryID = 7, ProductsProductID = 49 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 50, Height = 3, Width = 8, Length = 8, BoardFeet = 864 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 50 }, new { CategoryID = 7, ProductsProductID = 50 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 51, Height = 3, Width = 8, Length = 10, BoardFeet = 1080 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 51 }, new { CategoryID = 7, ProductsProductID = 51 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 52, Height = 3, Width = 8, Length = 12, BoardFeet = 1296 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 52 }, new { CategoryID = 7, ProductsProductID = 52 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 53, Height = 3, Width = 8, Length = 14, BoardFeet = 1512 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 53 }, new { CategoryID = 7, ProductsProductID = 53 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 54, Height = 3, Width = 8, Length = 16, BoardFeet = 1728 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 54 }, new { CategoryID = 7, ProductsProductID = 54 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 55, Height = 3, Width = 8, Length = 18, BoardFeet = 1944 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 55 }, new { CategoryID = 7, ProductsProductID = 55 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 56, Height = 3, Width = 8, Length = 20, BoardFeet = 2160 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 56 }, new { CategoryID = 7, ProductsProductID = 56 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 57, Height = 3, Width = 10, Length = 8, BoardFeet = 900 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 57 }, new { CategoryID = 7, ProductsProductID = 57 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 58, Height = 3, Width = 10, Length = 10, BoardFeet = 1125 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 58 }, new { CategoryID = 7, ProductsProductID = 58 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 59, Height = 3, Width = 10, Length = 12, BoardFeet = 1350 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 59 }, new { CategoryID = 7, ProductsProductID = 59 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 60, Height = 3, Width = 10, Length = 14, BoardFeet = 1575 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 60 }, new { CategoryID = 7, ProductsProductID = 60 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 61, Height = 3, Width = 10, Length = 16, BoardFeet = 1800 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 61 }, new { CategoryID = 7, ProductsProductID = 61 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 62, Height = 3, Width = 10, Length = 18, BoardFeet = 2025 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 62 }, new { CategoryID = 7, ProductsProductID = 62 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 63, Height = 3, Width = 10, Length = 20, BoardFeet = 2250 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 63 }, new { CategoryID = 7, ProductsProductID = 63 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 64, Height = 3, Width = 12, Length = 8, BoardFeet = 864 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 64 }, new { CategoryID = 7, ProductsProductID = 64 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 65, Height = 3, Width = 12, Length = 10, BoardFeet = 1080 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 65 }, new { CategoryID = 7, ProductsProductID = 65 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 66, Height = 3, Width = 12, Length = 12, BoardFeet = 1296 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 66 }, new { CategoryID = 7, ProductsProductID = 66 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 67, Height = 3, Width = 12, Length = 14, BoardFeet = 1512 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 67 }, new { CategoryID = 7, ProductsProductID = 67 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 68, Height = 3, Width = 12, Length = 16, BoardFeet = 1728 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 68 }, new { CategoryID = 7, ProductsProductID = 68 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 69, Height = 3, Width = 12, Length = 18, BoardFeet = 1944 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 69 }, new { CategoryID = 7, ProductsProductID = 69 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 70, Height = 3, Width = 12, Length = 20, BoardFeet = 2160 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 70 }, new { CategoryID = 7, ProductsProductID = 70 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 71, Height = 4, Width = 4, Length = 8, BoardFeet = 971 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 71 }, new { CategoryID = 7, ProductsProductID = 71 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 72, Height = 4, Width = 4, Length = 10, BoardFeet = 1213 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 72 }, new { CategoryID = 7, ProductsProductID = 72 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 73, Height = 4, Width = 4, Length = 12, BoardFeet = 1456 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 73 }, new { CategoryID = 7, ProductsProductID = 73 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 74, Height = 4, Width = 4, Length = 14, BoardFeet = 1699 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 74 }, new { CategoryID = 7, ProductsProductID = 74 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 75, Height = 4, Width = 4, Length = 16, BoardFeet = 1941 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 75 }, new { CategoryID = 7, ProductsProductID = 75 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 76, Height = 4, Width = 4, Length = 18, BoardFeet = 2148 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 76 }, new { CategoryID = 7, ProductsProductID = 76 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 77, Height = 4, Width = 4, Length = 20, BoardFeet = 2427 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 77 }, new { CategoryID = 7, ProductsProductID = 77 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 78, Height = 4, Width = 6, Length = 8, BoardFeet = 896 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 78 }, new { CategoryID = 7, ProductsProductID = 78 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 79, Height = 4, Width = 6, Length = 10, BoardFeet = 1120 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 79 }, new { CategoryID = 7, ProductsProductID = 79 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 80, Height = 4, Width = 6, Length = 12, BoardFeet = 1344 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 80 }, new { CategoryID = 7, ProductsProductID = 80 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 81, Height = 4, Width = 6, Length = 14, BoardFeet = 1568 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 81 }, new { CategoryID = 7, ProductsProductID = 81 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 82, Height = 4, Width = 6, Length = 16, BoardFeet = 1792 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 82 }, new { CategoryID = 7, ProductsProductID = 82 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 83, Height = 4, Width = 6, Length = 18, BoardFeet = 2016 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 83 }, new { CategoryID = 7, ProductsProductID = 83 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 84, Height = 4, Width = 6, Length = 20, BoardFeet = 2240 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 84 }, new { CategoryID = 7, ProductsProductID = 84 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 85, Height = 4, Width = 8, Length = 8, BoardFeet = 896 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 85 }, new { CategoryID = 7, ProductsProductID = 85 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 86, Height = 4, Width = 8, Length = 10, BoardFeet = 1120 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 86 }, new { CategoryID = 7, ProductsProductID = 86 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 87, Height = 4, Width = 8, Length = 12, BoardFeet = 1344 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 87 }, new { CategoryID = 7, ProductsProductID = 87 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 88, Height = 4, Width = 8, Length = 14, BoardFeet = 1568 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 88 }, new { CategoryID = 7, ProductsProductID = 88 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 89, Height = 4, Width = 8, Length = 16, BoardFeet = 1792 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 89 }, new { CategoryID = 7, ProductsProductID = 89 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 90, Height = 4, Width = 8, Length = 18, BoardFeet = 2016 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 90 }, new { CategoryID = 7, ProductsProductID = 90 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 91, Height = 4, Width = 8, Length = 20, BoardFeet = 2240 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 91 }, new { CategoryID = 7, ProductsProductID = 91 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 92, Height = 4, Width = 10, Length = 8, BoardFeet = 933 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 92 }, new { CategoryID = 7, ProductsProductID = 92 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 93, Height = 4, Width = 10, Length = 10, BoardFeet = 1167 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 93 }, new { CategoryID = 7, ProductsProductID = 93 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 94, Height = 4, Width = 10, Length = 12, BoardFeet = 1400 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 94 }, new { CategoryID = 7, ProductsProductID = 94 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 95, Height = 4, Width = 10, Length = 14, BoardFeet = 1633 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 95 }, new { CategoryID = 7, ProductsProductID = 95 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 96, Height = 4, Width = 10, Length = 16, BoardFeet = 1867 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 96 }, new { CategoryID = 7, ProductsProductID = 96 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 97, Height = 4, Width = 10, Length = 18, BoardFeet = 2100 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 97 }, new { CategoryID = 7, ProductsProductID = 97 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 98, Height = 4, Width = 10, Length = 20, BoardFeet = 2333 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 98 }, new { CategoryID = 7, ProductsProductID = 98 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 99, Height = 4, Width = 12, Length = 8, BoardFeet = 896 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 99 }, new { CategoryID = 7, ProductsProductID = 99 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 100, Height = 4, Width = 12, Length = 10, BoardFeet = 1120 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 100 }, new { CategoryID = 7, ProductsProductID = 100 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 101, Height = 4, Width = 12, Length = 12, BoardFeet = 1344 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 101 }, new { CategoryID = 7, ProductsProductID = 101 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 102, Height = 4, Width = 12, Length = 14, BoardFeet = 1568 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 102 }, new { CategoryID = 7, ProductsProductID = 102 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 103, Height = 4, Width = 12, Length = 16, BoardFeet = 1792 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 103 }, new { CategoryID = 7, ProductsProductID = 103 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 104, Height = 4, Width = 12, Length = 18, BoardFeet = 2016 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 104 }, new { CategoryID = 7, ProductsProductID = 104 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 105, Height = 4, Width = 12, Length = 20, BoardFeet = 2240 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 105 }, new { CategoryID = 7, ProductsProductID = 105 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 106, Height = 6, Width = 6, Length = 8, BoardFeet = 768 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 106 }, new { CategoryID = 7, ProductsProductID = 106 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 107, Height = 6, Width = 6, Length = 10, BoardFeet = 960 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 107 }, new { CategoryID = 7, ProductsProductID = 107 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 108, Height = 6, Width = 6, Length = 12, BoardFeet = 1152 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 108 }, new { CategoryID = 7, ProductsProductID = 108 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 109, Height = 6, Width = 6, Length = 14, BoardFeet = 1344 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 109 }, new { CategoryID = 7, ProductsProductID = 109 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 110, Height = 6, Width = 6, Length = 16, BoardFeet = 1536 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 110 }, new { CategoryID = 7, ProductsProductID = 110 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 111, Height = 6, Width = 6, Length = 18, BoardFeet = 1728 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 111 }, new { CategoryID = 7, ProductsProductID = 111 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 112, Height = 6, Width = 6, Length = 20, BoardFeet = 1920 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 112 }, new { CategoryID = 7, ProductsProductID = 112 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 113, Height = 6, Width = 8, Length = 8, BoardFeet = 768 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 113 }, new { CategoryID = 7, ProductsProductID = 113 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 114, Height = 6, Width = 8, Length = 10, BoardFeet = 960 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 114 }, new { CategoryID = 7, ProductsProductID = 114 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 115, Height = 6, Width = 8, Length = 12, BoardFeet = 1152 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 115 }, new { CategoryID = 7, ProductsProductID = 115 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 116, Height = 6, Width = 8, Length = 14, BoardFeet = 1344 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 116 }, new { CategoryID = 7, ProductsProductID = 116 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 117, Height = 6, Width = 8, Length = 16, BoardFeet = 1536 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 117 }, new { CategoryID = 7, ProductsProductID = 117 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 118, Height = 6, Width = 8, Length = 18, BoardFeet = 1728 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 118 }, new { CategoryID = 7, ProductsProductID = 118 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 119, Height = 6, Width = 8, Length = 20, BoardFeet = 1920 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 119 }, new { CategoryID = 7, ProductsProductID = 119 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 120, Height = 6, Width = 10, Length = 8, BoardFeet = 800 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 120 }, new { CategoryID = 7, ProductsProductID = 120 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 121, Height = 6, Width = 10, Length = 10, BoardFeet = 1000 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 121 }, new { CategoryID = 7, ProductsProductID = 121 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 122, Height = 6, Width = 10, Length = 12, BoardFeet = 1200 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 122 }, new { CategoryID = 7, ProductsProductID = 122 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 123, Height = 6, Width = 10, Length = 14, BoardFeet = 1400 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 123 }, new { CategoryID = 7, ProductsProductID = 123 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 124, Height = 6, Width = 10, Length = 16, BoardFeet = 1600 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 124 }, new { CategoryID = 7, ProductsProductID = 124 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 125, Height = 6, Width = 10, Length = 18, BoardFeet = 1800 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 125 }, new { CategoryID = 7, ProductsProductID = 125 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 126, Height = 6, Width = 10, Length = 20, BoardFeet = 2000 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 126 }, new { CategoryID = 7, ProductsProductID = 126 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 127, Height = 6, Width = 12, Length = 8, BoardFeet = 768 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 127 }, new { CategoryID = 7, ProductsProductID = 127 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 128, Height = 6, Width = 12, Length = 10, BoardFeet = 960 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 128 }, new { CategoryID = 7, ProductsProductID = 128 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 129, Height = 6, Width = 12, Length = 12, BoardFeet = 1152 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 129 }, new { CategoryID = 7, ProductsProductID = 129 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 130, Height = 6, Width = 12, Length = 14, BoardFeet = 1344 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 130 }, new { CategoryID = 7, ProductsProductID = 130 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 131, Height = 6, Width = 12, Length = 16, BoardFeet = 1536 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 131 }, new { CategoryID = 7, ProductsProductID = 131 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 132, Height = 6, Width = 12, Length = 18, BoardFeet = 1728 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 132 }, new { CategoryID = 7, ProductsProductID = 132 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 133, Height = 6, Width = 12, Length = 20, BoardFeet = 1920 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 1, ProductsProductID = 133 }, new { CategoryID = 7, ProductsProductID = 133 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 134, Height = 2, Width = 4, Length = 8, BoardFeet = 1109 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 2, ProductsProductID = 134 }, new { CategoryID = 5, ProductsProductID = 134 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 135, Height = 2, Width = 4, Length = 10, BoardFeet = 1387 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 2, ProductsProductID = 135 }, new { CategoryID = 5, ProductsProductID = 135 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 136, Height = 2, Width = 4, Length = 12, BoardFeet = 1664 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 2, ProductsProductID = 136 }, new { CategoryID = 5, ProductsProductID = 136 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 137, Height = 2, Width = 4, Length = 14, BoardFeet = 1941 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 2, ProductsProductID = 137 }, new { CategoryID = 5, ProductsProductID = 137 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 138, Height = 2, Width = 4, Length = 16, BoardFeet = 2219 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 2, ProductsProductID = 138 }, new { CategoryID = 5, ProductsProductID = 138 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 139, Height = 2, Width = 4, Length = 18, BoardFeet = 2496 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 2, ProductsProductID = 139 }, new { CategoryID = 5, ProductsProductID = 139 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 140, Height = 2, Width = 4, Length = 20, BoardFeet = 2773 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 2, ProductsProductID = 140 }, new { CategoryID = 5, ProductsProductID = 140 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 141, Height = 2, Width = 6, Length = 8, BoardFeet = 1024 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 2, ProductsProductID = 141 }, new { CategoryID = 5, ProductsProductID = 141 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 142, Height = 2, Width = 6, Length = 10, BoardFeet = 1280 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 2, ProductsProductID = 142 }, new { CategoryID = 5, ProductsProductID = 142 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 143, Height = 2, Width = 6, Length = 12, BoardFeet = 1536 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 2, ProductsProductID = 143 }, new { CategoryID = 5, ProductsProductID = 143 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 144, Height = 2, Width = 6, Length = 14, BoardFeet = 1792 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 2, ProductsProductID = 144 }, new { CategoryID = 5, ProductsProductID = 144 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 145, Height = 2, Width = 6, Length = 16, BoardFeet = 2048 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 2, ProductsProductID = 145 }, new { CategoryID = 5, ProductsProductID = 145 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 146, Height = 2, Width = 6, Length = 18, BoardFeet = 2304 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 2, ProductsProductID = 146 }, new { CategoryID = 5, ProductsProductID = 146 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 147, Height = 2, Width = 6, Length = 20, BoardFeet = 2560 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 2, ProductsProductID = 147 }, new { CategoryID = 5, ProductsProductID = 147 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 148, Height = 2, Width = 4, Length = 8, BoardFeet = 1109 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 148 }, new { CategoryID = 5, ProductsProductID = 148 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 149, Height = 2, Width = 4, Length = 10, BoardFeet = 1387 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 149 }, new { CategoryID = 5, ProductsProductID = 149 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 150, Height = 2, Width = 4, Length = 12, BoardFeet = 1664 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 150 }, new { CategoryID = 5, ProductsProductID = 150 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 151, Height = 2, Width = 4, Length = 14, BoardFeet = 1941 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 151 }, new { CategoryID = 5, ProductsProductID = 151 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 152, Height = 2, Width = 4, Length = 16, BoardFeet = 2219 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 152 }, new { CategoryID = 5, ProductsProductID = 152 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 153, Height = 2, Width = 4, Length = 18, BoardFeet = 2496 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 153 }, new { CategoryID = 5, ProductsProductID = 153 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 154, Height = 2, Width = 4, Length = 20, BoardFeet = 2773 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 154 }, new { CategoryID = 5, ProductsProductID = 154 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 155, Height = 2, Width = 6, Length = 8, BoardFeet = 1024 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 155 }, new { CategoryID = 5, ProductsProductID = 155 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 156, Height = 2, Width = 6, Length = 10, BoardFeet = 1280 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 156 }, new { CategoryID = 5, ProductsProductID = 156 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 157, Height = 2, Width = 6, Length = 12, BoardFeet = 1536 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 157 }, new { CategoryID = 5, ProductsProductID = 157 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 158, Height = 2, Width = 6, Length = 14, BoardFeet = 1792 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 158 }, new { CategoryID = 5, ProductsProductID = 158 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 159, Height = 2, Width = 6, Length = 16, BoardFeet = 2048 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 159 }, new { CategoryID = 5, ProductsProductID = 159 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 160, Height = 2, Width = 6, Length = 18, BoardFeet = 2304 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 160 }, new { CategoryID = 5, ProductsProductID = 160 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 161, Height = 2, Width = 6, Length = 20, BoardFeet = 2560 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 161 }, new { CategoryID = 5, ProductsProductID = 161 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 162, Height = 2, Width = 8, Length = 8, BoardFeet = 512 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 162 }, new { CategoryID = 5, ProductsProductID = 162 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 163, Height = 2, Width = 8, Length = 10, BoardFeet = 640 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 163 }, new { CategoryID = 5, ProductsProductID = 163 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 164, Height = 2, Width = 8, Length = 12, BoardFeet = 768 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 164 }, new { CategoryID = 5, ProductsProductID = 164 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 165, Height = 2, Width = 8, Length = 14, BoardFeet = 896 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 165 }, new { CategoryID = 5, ProductsProductID = 165 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 166, Height = 2, Width = 8, Length = 16, BoardFeet = 1024 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 166 }, new { CategoryID = 5, ProductsProductID = 166 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 167, Height = 2, Width = 8, Length = 18, BoardFeet = 1152 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 167 }, new { CategoryID = 5, ProductsProductID = 167 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 168, Height = 2, Width = 8, Length = 20, BoardFeet = 1280 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 168 }, new { CategoryID = 5, ProductsProductID = 168 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 169, Height = 2, Width = 10, Length = 8, BoardFeet = 533 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 169 }, new { CategoryID = 5, ProductsProductID = 169 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 170, Height = 2, Width = 10, Length = 10, BoardFeet = 667 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 170 }, new { CategoryID = 5, ProductsProductID = 170 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 171, Height = 2, Width = 10, Length = 12, BoardFeet = 800 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 171 }, new { CategoryID = 5, ProductsProductID = 171 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 172, Height = 2, Width = 10, Length = 14, BoardFeet = 934 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 172 }, new { CategoryID = 5, ProductsProductID = 172 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 173, Height = 2, Width = 10, Length = 16, BoardFeet = 1067 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 173 }, new { CategoryID = 5, ProductsProductID = 173 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 174, Height = 2, Width = 10, Length = 18, BoardFeet = 1200 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 174 }, new { CategoryID = 5, ProductsProductID = 174 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 175, Height = 2, Width = 10, Length = 20, BoardFeet = 1334 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 175 }, new { CategoryID = 5, ProductsProductID = 175 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 176, Height = 2, Width = 12, Length = 8, BoardFeet = 512 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 176 }, new { CategoryID = 5, ProductsProductID = 176 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 177, Height = 2, Width = 12, Length = 10, BoardFeet = 640 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 177 }, new { CategoryID = 5, ProductsProductID = 177 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 178, Height = 2, Width = 12, Length = 12, BoardFeet = 768 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 178 }, new { CategoryID = 5, ProductsProductID = 178 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 179, Height = 2, Width = 12, Length = 14, BoardFeet = 896 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 179 }, new { CategoryID = 5, ProductsProductID = 179 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 180, Height = 2, Width = 12, Length = 16, BoardFeet = 1024 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 180 }, new { CategoryID = 5, ProductsProductID = 180 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 181, Height = 2, Width = 12, Length = 18, BoardFeet = 1152 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 181 }, new { CategoryID = 5, ProductsProductID = 181 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 182, Height = 2, Width = 12, Length = 20, BoardFeet = 1280 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 182 }, new { CategoryID = 5, ProductsProductID = 182 }));

        }
    }
}
