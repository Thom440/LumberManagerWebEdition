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
        }
    }
}
