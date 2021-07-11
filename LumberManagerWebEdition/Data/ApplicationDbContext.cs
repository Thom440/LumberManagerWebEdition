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

            builder.Entity<Product>().HasData(new Product { ProductID = 183, Height = 4, Width = 4, Length = 8, BoardFeet = 971 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 183 }, new { CategoryID = 5, ProductsProductID = 183 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 184, Height = 4, Width = 4, Length = 10, BoardFeet = 1213 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 184 }, new { CategoryID = 5, ProductsProductID = 184 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 185, Height = 4, Width = 4, Length = 12, BoardFeet = 1456 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 185 }, new { CategoryID = 5, ProductsProductID = 185 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 186, Height = 4, Width = 4, Length = 14, BoardFeet = 1699 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 186 }, new { CategoryID = 5, ProductsProductID = 186 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 187, Height = 4, Width = 4, Length = 16, BoardFeet = 1941 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 187 }, new { CategoryID = 5, ProductsProductID = 187 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 188, Height = 4, Width = 4, Length = 18, BoardFeet = 2184 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 188 }, new { CategoryID = 5, ProductsProductID = 188 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 189, Height = 4, Width = 4, Length = 20, BoardFeet = 2427 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 189 }, new { CategoryID = 5, ProductsProductID = 189 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 190, Height = 4, Width = 6, Length = 8, BoardFeet = 896 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 190 }, new { CategoryID = 5, ProductsProductID = 190 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 191, Height = 4, Width = 6, Length = 10, BoardFeet = 1120 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 191 }, new { CategoryID = 5, ProductsProductID = 191 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 192, Height = 4, Width = 6, Length = 12, BoardFeet = 1344 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 192 }, new { CategoryID = 5, ProductsProductID = 192 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 193, Height = 4, Width = 6, Length = 14, BoardFeet = 1568 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 193 }, new { CategoryID = 5, ProductsProductID = 193 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 194, Height = 4, Width = 6, Length = 16, BoardFeet = 1792 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 194 }, new { CategoryID = 5, ProductsProductID = 194 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 195, Height = 4, Width = 6, Length = 18, BoardFeet = 2016 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 195 }, new { CategoryID = 5, ProductsProductID = 195 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 196, Height = 4, Width = 6, Length = 20, BoardFeet = 2240 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 196 }, new { CategoryID = 5, ProductsProductID = 196 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 197, Height = 4, Width = 8, Length = 8, BoardFeet = 512 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 197 }, new { CategoryID = 5, ProductsProductID = 197 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 198, Height = 4, Width = 8, Length = 10, BoardFeet = 640 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 198 }, new { CategoryID = 5, ProductsProductID = 198 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 199, Height = 4, Width = 8, Length = 12, BoardFeet = 768 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 199 }, new { CategoryID = 5, ProductsProductID = 199 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 200, Height = 4, Width = 8, Length = 14, BoardFeet = 896 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 200 }, new { CategoryID = 5, ProductsProductID = 200 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 201, Height = 4, Width = 8, Length = 16, BoardFeet = 1024 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 201 }, new { CategoryID = 5, ProductsProductID = 201 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 202, Height = 4, Width = 8, Length = 18, BoardFeet = 1152 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 202 }, new { CategoryID = 5, ProductsProductID = 202 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 203, Height = 4, Width = 8, Length = 20, BoardFeet = 1280 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 203 }, new { CategoryID = 5, ProductsProductID = 203 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 204, Height = 4, Width = 10, Length = 8, BoardFeet = 534 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 204 }, new { CategoryID = 5, ProductsProductID = 204 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 205, Height = 4, Width = 10, Length = 10, BoardFeet = 667 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 205 }, new { CategoryID = 5, ProductsProductID = 205 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 206, Height = 4, Width = 10, Length = 12, BoardFeet = 800 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 206 }, new { CategoryID = 5, ProductsProductID = 206 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 207, Height = 4, Width = 10, Length = 14, BoardFeet = 934 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 207 }, new { CategoryID = 5, ProductsProductID = 207 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 208, Height = 4, Width = 10, Length = 16, BoardFeet = 1067 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 208 }, new { CategoryID = 5, ProductsProductID = 208 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 209, Height = 4, Width = 10, Length = 18, BoardFeet = 1200 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 209 }, new { CategoryID = 5, ProductsProductID = 209 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 210, Height = 4, Width = 10, Length = 20, BoardFeet = 1334 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 210 }, new { CategoryID = 5, ProductsProductID = 210 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 211, Height = 4, Width = 12, Length = 8, BoardFeet = 512 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 211 }, new { CategoryID = 5, ProductsProductID = 211 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 212, Height = 4, Width = 12, Length = 10, BoardFeet = 640 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 212 }, new { CategoryID = 5, ProductsProductID = 212 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 213, Height = 4, Width = 12, Length = 12, BoardFeet = 768 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 213 }, new { CategoryID = 5, ProductsProductID = 213 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 214, Height = 4, Width = 12, Length = 14, BoardFeet = 896 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 214 }, new { CategoryID = 5, ProductsProductID = 214 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 215, Height = 4, Width = 12, Length = 16, BoardFeet = 1024 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 215 }, new { CategoryID = 5, ProductsProductID = 215 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 216, Height = 4, Width = 12, Length = 18, BoardFeet = 1152 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 216 }, new { CategoryID = 5, ProductsProductID = 216 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 217, Height = 4, Width = 12, Length = 20, BoardFeet = 1280 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 217 }, new { CategoryID = 5, ProductsProductID = 217 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 218, Height = 4, Width = 4, Length = 8, BoardFeet = 971 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 218 }, new { CategoryID = 5, ProductsProductID = 218 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 219, Height = 4, Width = 4, Length = 10, BoardFeet = 1213 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 219 }, new { CategoryID = 5, ProductsProductID = 219 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 220, Height = 4, Width = 4, Length = 12, BoardFeet = 1456 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 220 }, new { CategoryID = 5, ProductsProductID = 220 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 221, Height = 4, Width = 4, Length = 14, BoardFeet = 1699 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 221 }, new { CategoryID = 5, ProductsProductID = 221 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 222, Height = 4, Width = 4, Length = 16, BoardFeet = 1941 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 222 }, new { CategoryID = 5, ProductsProductID = 222 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 223, Height = 4, Width = 4, Length = 18, BoardFeet = 2184 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 223 }, new { CategoryID = 5, ProductsProductID = 223 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 224, Height = 4, Width = 4, Length = 20, BoardFeet = 2427 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 224 }, new { CategoryID = 5, ProductsProductID = 224 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 225, Height = 4, Width = 6, Length = 8, BoardFeet = 896 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 225 }, new { CategoryID = 5, ProductsProductID = 225 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 226, Height = 4, Width = 6, Length = 10, BoardFeet = 1120 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 226 }, new { CategoryID = 5, ProductsProductID = 226 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 227, Height = 4, Width = 6, Length = 12, BoardFeet = 1344 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 227 }, new { CategoryID = 5, ProductsProductID = 227 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 228, Height = 4, Width = 6, Length = 14, BoardFeet = 1568 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 228 }, new { CategoryID = 5, ProductsProductID = 228 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 229, Height = 4, Width = 6, Length = 16, BoardFeet = 1792 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 229 }, new { CategoryID = 5, ProductsProductID = 229 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 230, Height = 4, Width = 6, Length = 18, BoardFeet = 2016 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 230 }, new { CategoryID = 5, ProductsProductID = 230 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 231, Height = 4, Width = 6, Length = 20, BoardFeet = 2240 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 231 }, new { CategoryID = 5, ProductsProductID = 231 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 232, Height = 4, Width = 8, Length = 8, BoardFeet = 896 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 232 }, new { CategoryID = 5, ProductsProductID = 232 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 233, Height = 4, Width = 8, Length = 10, BoardFeet = 1120 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 233 }, new { CategoryID = 5, ProductsProductID = 233 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 234, Height = 4, Width = 8, Length = 12, BoardFeet = 1344 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 234 }, new { CategoryID = 5, ProductsProductID = 234 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 235, Height = 4, Width = 8, Length = 14, BoardFeet = 1568 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 235 }, new { CategoryID = 5, ProductsProductID = 235 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 236, Height = 4, Width = 8, Length = 16, BoardFeet = 1792 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 236 }, new { CategoryID = 5, ProductsProductID = 236 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 237, Height = 4, Width = 8, Length = 18, BoardFeet = 2016 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 237 }, new { CategoryID = 5, ProductsProductID = 237 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 238, Height = 4, Width = 8, Length = 20, BoardFeet = 2240 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 238 }, new { CategoryID = 5, ProductsProductID = 238 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 239, Height = 4, Width = 10, Length = 8, BoardFeet = 933 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 239 }, new { CategoryID = 5, ProductsProductID = 239 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 240, Height = 4, Width = 10, Length = 10, BoardFeet = 1167 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 240 }, new { CategoryID = 5, ProductsProductID = 240 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 241, Height = 4, Width = 10, Length = 12, BoardFeet = 1400 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 241 }, new { CategoryID = 5, ProductsProductID = 241 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 242, Height = 4, Width = 10, Length = 14, BoardFeet = 1633 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 242 }, new { CategoryID = 5, ProductsProductID = 242 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 243, Height = 4, Width = 10, Length = 16, BoardFeet = 1867 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 243 }, new { CategoryID = 5, ProductsProductID = 243 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 244, Height = 4, Width = 10, Length = 18, BoardFeet = 2100 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 244 }, new { CategoryID = 5, ProductsProductID = 244 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 245, Height = 4, Width = 10, Length = 20, BoardFeet = 2333 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 245 }, new { CategoryID = 5, ProductsProductID = 245 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 246, Height = 4, Width = 12, Length = 8, BoardFeet = 896 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 246 }, new { CategoryID = 5, ProductsProductID = 246 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 247, Height = 4, Width = 12, Length = 10, BoardFeet = 1120 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 247 }, new { CategoryID = 5, ProductsProductID = 247 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 248, Height = 4, Width = 12, Length = 12, BoardFeet = 1344 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 248 }, new { CategoryID = 5, ProductsProductID = 248 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 249, Height = 4, Width = 12, Length = 14, BoardFeet = 1568 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 249 }, new { CategoryID = 5, ProductsProductID = 249 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 250, Height = 4, Width = 12, Length = 16, BoardFeet = 1792 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 250 }, new { CategoryID = 5, ProductsProductID = 250 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 251, Height = 4, Width = 12, Length = 18, BoardFeet = 2016 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 251 }, new { CategoryID = 5, ProductsProductID = 251 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 252, Height = 4, Width = 12, Length = 20, BoardFeet = 2240 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 252 }, new { CategoryID = 5, ProductsProductID = 252 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 253, Height = 3, Width = 4, Length = 8, BoardFeet = 416 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 253 }, new { CategoryID = 5, ProductsProductID = 253 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 254, Height = 3, Width = 4, Length = 10, BoardFeet = 520 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 254 }, new { CategoryID = 5, ProductsProductID = 254 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 255, Height = 3, Width = 4, Length = 12, BoardFeet = 624 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 255 }, new { CategoryID = 5, ProductsProductID = 255 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 256, Height = 3, Width = 4, Length = 14, BoardFeet = 728 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 256 }, new { CategoryID = 5, ProductsProductID = 256 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 257, Height = 3, Width = 4, Length = 16, BoardFeet = 832 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 257 }, new { CategoryID = 5, ProductsProductID = 257 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 258, Height = 3, Width = 4, Length = 18, BoardFeet = 936 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 258 }, new { CategoryID = 5, ProductsProductID = 258 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 259, Height = 3, Width = 4, Length = 20, BoardFeet = 1040 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 259 }, new { CategoryID = 5, ProductsProductID = 259 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 260, Height = 3, Width = 6, Length = 8, BoardFeet = 384 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 260 }, new { CategoryID = 5, ProductsProductID = 260 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 261, Height = 3, Width = 6, Length = 10, BoardFeet = 480 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 261 }, new { CategoryID = 5, ProductsProductID = 261 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 262, Height = 3, Width = 6, Length = 12, BoardFeet = 576 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 262 }, new { CategoryID = 5, ProductsProductID = 262 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 263, Height = 3, Width = 6, Length = 14, BoardFeet = 672 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 263 }, new { CategoryID = 5, ProductsProductID = 263 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 264, Height = 3, Width = 6, Length = 16, BoardFeet = 768 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 264 }, new { CategoryID = 5, ProductsProductID = 264 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 265, Height = 3, Width = 6, Length = 18, BoardFeet = 864 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 265 }, new { CategoryID = 5, ProductsProductID = 265 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 266, Height = 3, Width = 6, Length = 20, BoardFeet = 960 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 266 }, new { CategoryID = 5, ProductsProductID = 266 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 267, Height = 3, Width = 8, Length = 8, BoardFeet = 384 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 267 }, new { CategoryID = 5, ProductsProductID = 267 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 268, Height = 3, Width = 8, Length = 10, BoardFeet = 480 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 268 }, new { CategoryID = 5, ProductsProductID = 268 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 269, Height = 3, Width = 8, Length = 12, BoardFeet = 576 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 269 }, new { CategoryID = 5, ProductsProductID = 269 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 270, Height = 3, Width = 8, Length = 14, BoardFeet = 672 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 270 }, new { CategoryID = 5, ProductsProductID = 270 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 271, Height = 3, Width = 8, Length = 16, BoardFeet = 768 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 271 }, new { CategoryID = 5, ProductsProductID = 271 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 272, Height = 3, Width = 8, Length = 18, BoardFeet = 864 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 272 }, new { CategoryID = 5, ProductsProductID = 272 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 273, Height = 3, Width = 8, Length = 20, BoardFeet = 960 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 273 }, new { CategoryID = 5, ProductsProductID = 273 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 274, Height = 3, Width = 10, Length = 8, BoardFeet = 400 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 274 }, new { CategoryID = 5, ProductsProductID = 274 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 275, Height = 3, Width = 10, Length = 10, BoardFeet = 500 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 275 }, new { CategoryID = 5, ProductsProductID = 275 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 276, Height = 3, Width = 10, Length = 12, BoardFeet = 600 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 276 }, new { CategoryID = 5, ProductsProductID = 276 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 277, Height = 3, Width = 10, Length = 14, BoardFeet = 700 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 277 }, new { CategoryID = 5, ProductsProductID = 277 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 278, Height = 3, Width = 10, Length = 16, BoardFeet = 800 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 278 }, new { CategoryID = 5, ProductsProductID = 278 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 279, Height = 3, Width = 10, Length = 18, BoardFeet = 900 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 279 }, new { CategoryID = 5, ProductsProductID = 279 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 280, Height = 3, Width = 10, Length = 20, BoardFeet = 1000 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 280 }, new { CategoryID = 5, ProductsProductID = 280 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 281, Height = 3, Width = 12, Length = 8, BoardFeet = 384 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 281 }, new { CategoryID = 5, ProductsProductID = 281 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 282, Height = 3, Width = 12, Length = 10, BoardFeet = 480 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 282 }, new { CategoryID = 5, ProductsProductID = 282 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 283, Height = 3, Width = 12, Length = 12, BoardFeet = 576 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 283 }, new { CategoryID = 5, ProductsProductID = 283 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 284, Height = 3, Width = 12, Length = 14, BoardFeet = 672 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 284 }, new { CategoryID = 5, ProductsProductID = 284 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 285, Height = 3, Width = 12, Length = 16, BoardFeet = 768 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 285 }, new { CategoryID = 5, ProductsProductID = 285 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 286, Height = 3, Width = 12, Length = 18, BoardFeet = 864 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 286 }, new { CategoryID = 5, ProductsProductID = 286 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 287, Height = 3, Width = 12, Length = 20, BoardFeet = 960 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 3, ProductsProductID = 287 }, new { CategoryID = 5, ProductsProductID = 287 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 288, Height = 3, Width = 4, Length = 8, BoardFeet = 936 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 288 }, new { CategoryID = 5, ProductsProductID = 288 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 289, Height = 3, Width = 4, Length = 10, BoardFeet = 1170 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 289 }, new { CategoryID = 5, ProductsProductID = 289 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 290, Height = 3, Width = 4, Length = 12, BoardFeet = 1404 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 290 }, new { CategoryID = 5, ProductsProductID = 290 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 291, Height = 3, Width = 4, Length = 14, BoardFeet = 1638 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 291 }, new { CategoryID = 5, ProductsProductID = 291 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 292, Height = 3, Width = 4, Length = 16, BoardFeet = 1872 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 292 }, new { CategoryID = 5, ProductsProductID = 292 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 293, Height = 3, Width = 4, Length = 18, BoardFeet = 2106 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 293 }, new { CategoryID = 5, ProductsProductID = 293 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 294, Height = 3, Width = 4, Length = 20, BoardFeet = 2340 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 294 }, new { CategoryID = 5, ProductsProductID = 294 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 295, Height = 3, Width = 6, Length = 8, BoardFeet = 864 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 295 }, new { CategoryID = 5, ProductsProductID = 295 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 296, Height = 3, Width = 6, Length = 10, BoardFeet = 1080 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 296 }, new { CategoryID = 5, ProductsProductID = 296 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 297, Height = 3, Width = 6, Length = 12, BoardFeet = 1296 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 297 }, new { CategoryID = 5, ProductsProductID = 297 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 298, Height = 3, Width = 6, Length = 14, BoardFeet = 1512 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 298 }, new { CategoryID = 5, ProductsProductID = 298 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 299, Height = 3, Width = 6, Length = 16, BoardFeet = 1728 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 299 }, new { CategoryID = 5, ProductsProductID = 299 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 300, Height = 3, Width = 6, Length = 18, BoardFeet = 1944 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 300 }, new { CategoryID = 5, ProductsProductID = 300 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 301, Height = 3, Width = 6, Length = 20, BoardFeet = 2160 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 301 }, new { CategoryID = 5, ProductsProductID = 301 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 302, Height = 3, Width = 8, Length = 8, BoardFeet = 864 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 302 }, new { CategoryID = 5, ProductsProductID = 302 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 303, Height = 3, Width = 8, Length = 10, BoardFeet = 1080 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 303 }, new { CategoryID = 5, ProductsProductID = 303 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 304, Height = 3, Width = 8, Length = 12, BoardFeet = 1296 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 304 }, new { CategoryID = 5, ProductsProductID = 304 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 305, Height = 3, Width = 8, Length = 14, BoardFeet = 1512 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 305 }, new { CategoryID = 5, ProductsProductID = 305 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 306, Height = 3, Width = 8, Length = 16, BoardFeet = 1728 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 306 }, new { CategoryID = 5, ProductsProductID = 306 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 307, Height = 3, Width = 8, Length = 18, BoardFeet = 1944 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 307 }, new { CategoryID = 5, ProductsProductID = 307 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 308, Height = 3, Width = 8, Length = 20, BoardFeet = 2160 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 308 }, new { CategoryID = 5, ProductsProductID = 308 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 309, Height = 3, Width = 10, Length = 8, BoardFeet = 900 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 309 }, new { CategoryID = 5, ProductsProductID = 309 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 310, Height = 3, Width = 10, Length = 10, BoardFeet = 1125 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 310 }, new { CategoryID = 5, ProductsProductID = 310 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 311, Height = 3, Width = 10, Length = 12, BoardFeet = 1350 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 311 }, new { CategoryID = 5, ProductsProductID = 311 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 312, Height = 3, Width = 10, Length = 14, BoardFeet = 1575 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 312 }, new { CategoryID = 5, ProductsProductID = 312 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 313, Height = 3, Width = 10, Length = 16, BoardFeet = 1800 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 313 }, new { CategoryID = 5, ProductsProductID = 313 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 314, Height = 3, Width = 10, Length = 18, BoardFeet = 2025 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 314 }, new { CategoryID = 5, ProductsProductID = 314 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 315, Height = 3, Width = 10, Length = 20, BoardFeet = 2250 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 315 }, new { CategoryID = 5, ProductsProductID = 315 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 316, Height = 3, Width = 12, Length = 8, BoardFeet = 864 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 316 }, new { CategoryID = 5, ProductsProductID = 316 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 317, Height = 3, Width = 12, Length = 10, BoardFeet = 1080 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 317 }, new { CategoryID = 5, ProductsProductID = 317 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 318, Height = 3, Width = 12, Length = 12, BoardFeet = 1296 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 318 }, new { CategoryID = 5, ProductsProductID = 318 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 319, Height = 3, Width = 12, Length = 14, BoardFeet = 1512 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 319 }, new { CategoryID = 5, ProductsProductID = 319 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 320, Height = 3, Width = 12, Length = 16, BoardFeet = 1728 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 320 }, new { CategoryID = 5, ProductsProductID = 320 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 321, Height = 3, Width = 12, Length = 18, BoardFeet = 1944 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 321 }, new { CategoryID = 5, ProductsProductID = 321 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 322, Height = 3, Width = 12, Length = 20, BoardFeet = 2160 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 322 }, new { CategoryID = 5, ProductsProductID = 322 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 323, Height = 6, Width = 6, Length = 8, BoardFeet = 768 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 323 }, new { CategoryID = 5, ProductsProductID = 323 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 324, Height = 6, Width = 6, Length = 10, BoardFeet = 960 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 324 }, new { CategoryID = 5, ProductsProductID = 324 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 325, Height = 6, Width = 6, Length = 12, BoardFeet = 1152 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 325 }, new { CategoryID = 5, ProductsProductID = 325 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 326, Height = 6, Width = 6, Length = 14, BoardFeet = 1344 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 326 }, new { CategoryID = 5, ProductsProductID = 326 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 327, Height = 6, Width = 6, Length = 16, BoardFeet = 1536 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 327 }, new { CategoryID = 5, ProductsProductID = 327 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 328, Height = 6, Width = 6, Length = 18, BoardFeet = 1728 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 328 }, new { CategoryID = 5, ProductsProductID = 328 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 329, Height = 6, Width = 6, Length = 20, BoardFeet = 1920 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 329 }, new { CategoryID = 5, ProductsProductID = 329 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 330, Height = 6, Width = 8, Length = 8, BoardFeet = 768 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 330 }, new { CategoryID = 5, ProductsProductID = 330 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 331, Height = 6, Width = 8, Length = 10, BoardFeet = 960 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 331 }, new { CategoryID = 5, ProductsProductID = 331 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 332, Height = 6, Width = 8, Length = 12, BoardFeet = 1152 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 332 }, new { CategoryID = 5, ProductsProductID = 332 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 333, Height = 6, Width = 8, Length = 14, BoardFeet = 1344 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 333 }, new { CategoryID = 5, ProductsProductID = 333 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 334, Height = 6, Width = 8, Length = 16, BoardFeet = 1536 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 334 }, new { CategoryID = 5, ProductsProductID = 334 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 335, Height = 6, Width = 8, Length = 18, BoardFeet = 1728 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 335 }, new { CategoryID = 5, ProductsProductID = 335 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 336, Height = 6, Width = 8, Length = 20, BoardFeet = 1920 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 336 }, new { CategoryID = 5, ProductsProductID = 336 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 337, Height = 6, Width = 10, Length = 8, BoardFeet = 800 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 337 }, new { CategoryID = 5, ProductsProductID = 337 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 338, Height = 6, Width = 10, Length = 10, BoardFeet = 1000 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 338 }, new { CategoryID = 5, ProductsProductID = 338 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 339, Height = 6, Width = 10, Length = 12, BoardFeet = 1200 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 339 }, new { CategoryID = 5, ProductsProductID = 339 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 340, Height = 6, Width = 10, Length = 14, BoardFeet = 1400 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 340 }, new { CategoryID = 5, ProductsProductID = 340 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 341, Height = 6, Width = 10, Length = 16, BoardFeet = 1600 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 341 }, new { CategoryID = 5, ProductsProductID = 341 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 342, Height = 6, Width = 10, Length = 18, BoardFeet = 1800 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 342 }, new { CategoryID = 5, ProductsProductID = 342 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 343, Height = 6, Width = 10, Length = 20, BoardFeet = 2000 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 343 }, new { CategoryID = 5, ProductsProductID = 343 }));

            builder.Entity<Product>().HasData(new Product { ProductID = 344, Height = 6, Width = 12, Length = 8, BoardFeet = 768 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 344 }, new { CategoryID = 5, ProductsProductID = 344 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 345, Height = 6, Width = 12, Length = 10, BoardFeet = 960 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 345 }, new { CategoryID = 5, ProductsProductID = 345 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 346, Height = 6, Width = 12, Length = 12, BoardFeet = 1152 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 346 }, new { CategoryID = 5, ProductsProductID = 346 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 347, Height = 6, Width = 12, Length = 14, BoardFeet = 1344 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 347 }, new { CategoryID = 5, ProductsProductID = 347 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 348, Height = 6, Width = 12, Length = 16, BoardFeet = 1536 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 348 }, new { CategoryID = 5, ProductsProductID = 348 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 349, Height = 6, Width = 12, Length = 18, BoardFeet = 1728 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 349 }, new { CategoryID = 5, ProductsProductID = 349 }));
            builder.Entity<Product>().HasData(new Product { ProductID = 350, Height = 6, Width = 12, Length = 20, BoardFeet = 1920 });
            builder.Entity<Product>().HasMany(p => p.Category).WithMany(c => c.Products).UsingEntity(junctionTable => junctionTable.HasData(new { CategoryID = 4, ProductsProductID = 350 }, new { CategoryID = 5, ProductsProductID = 350 }));

        }
    }
}
