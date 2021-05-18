 using LumberManagerWebEdition.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LumberManagerWebEdition.Data
{
    public static class ProductDb
    {
        public static async Task<Product> AddProductAsync(ApplicationDbContext _context, Product p)
        {
            // Add to database
            _context.Products.Add(p);
            for (int i = 0; i < p.Category.Count; i++)
            {
                _context.Categories.Attach(p.Category[i]);
            }
            await _context.SaveChangesAsync();
            return p;
        }

        public static Product GetProduct(ApplicationDbContext _context, int? id)
        {
            Product product = (from p in _context.Products
                               where p.ProductID == id
                               select p).Include(nameof(Product.Category)).Single();
            return product;
        }

        public static async Task<List<Product>> GetAllProductsAsync(ApplicationDbContext _context, int pageSize, int pageNum)
        {
            List<Product> products = await (from p in _context.Products
                                      select p).Skip(pageSize * (pageNum - 1))
                                               .Take(pageSize)
                                               .Include(nameof(Product.Category))
                                               .ToListAsync();
            products = products.OrderBy(p => p.Height)
                                       .ThenBy(p => p.Width)
                                       .ThenBy(p => p.Length)
                                       .ThenBy(p => p.Category[1].CategoryName)
                                       .ThenBy(p => p.Category[0].CategoryName).ToList();
            return products;
        }

        public static async Task<List<Product>> GetAllProductsAsync(ApplicationDbContext _context, int pageSize, int pageNum, byte height,
                                                                                                byte width, byte length, string category, string treatmentType)
        {
            List<Product> products = await (from p in _context.Products
                                            where p.Height == height && p.Width == width && p.Length == length
                                            select p).Skip(pageSize * (pageNum - 1))
                                               .Take(pageSize)
                                               .Include(nameof(Product.Category))
                                               .ToListAsync();
            products = products.OrderBy(p => p.Height)
                                       .ThenBy(p => p.Width)
                                       .ThenBy(p => p.Length)
                                       .ThenBy(p => p.Category[1].CategoryName)
                                       .ThenBy(p => p.Category[0].CategoryName).ToList();

            List<Product> newProducts = new List<Product>();
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Category[0].CategoryName == category && products[i].Category[1].CategoryName == treatmentType)
                {
                    newProducts.Add(products[i]);
                }
            }
            return newProducts;
        }

        public static async Task<List<Product>> GetAllProductsAsync(ApplicationDbContext _context, int pageSize, int pageNum, byte height,
                                                                                                byte width, byte length, string category)
        {
            List<Product> products = await (from p in _context.Products
                                            where p.Height == height && p.Width == width && p.Length == length
                                            select p).Skip(pageSize * (pageNum - 1))
                                               .Take(pageSize)
                                               .Include(nameof(Product.Category))
                                               .ToListAsync();
            products = products.OrderBy(p => p.Height)
                                       .ThenBy(p => p.Width)
                                       .ThenBy(p => p.Length)
                                       .ThenBy(p => p.Category[1].CategoryName)
                                       .ThenBy(p => p.Category[0].CategoryName).ToList();

            List<Product> newProducts = new List<Product>();
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Category[0].CategoryName == category)
                {
                    newProducts.Add(products[i]);
                }
            }
            return newProducts;
        }

        public static async Task<List<Product>> GetAllProductsAsync(ApplicationDbContext _context, int pageSize, int pageNum, byte height,
                                                                                                byte width, byte length)
        {
            List<Product> products = await (from p in _context.Products
                                            where p.Height == height && p.Width == width && p.Length == length
                                            select p).Skip(pageSize * (pageNum - 1))
                                               .Take(pageSize)
                                               .Include(nameof(Product.Category))
                                               .ToListAsync();
            products = products.OrderBy(p => p.Height)
                                       .ThenBy(p => p.Width)
                                       .ThenBy(p => p.Length)
                                       .ThenBy(p => p.Category[1].CategoryName)
                                       .ThenBy(p => p.Category[0].CategoryName).ToList();
            return products;
        }

        public static async Task<List<Product>> GetAllProductsAsync(ApplicationDbContext _context, int pageSize, int pageNum, byte height,
                                                                                                byte width)
        {
            List<Product> products = await (from p in _context.Products
                                            where p.Height == height && p.Width == width
                                            select p).Skip(pageSize * (pageNum - 1))
                                               .Take(pageSize)
                                               .Include(nameof(Product.Category))
                                               .ToListAsync();
            products = products.OrderBy(p => p.Height)
                                       .ThenBy(p => p.Width)
                                       .ThenBy(p => p.Length)
                                       .ThenBy(p => p.Category[1].CategoryName)
                                       .ThenBy(p => p.Category[0].CategoryName).ToList();
            return products;
        }

        public static async Task<List<Product>> GetAllProductsAsync(ApplicationDbContext _context, int pageSize, int pageNum, byte height)
        {
            List<Product> products = await (from p in _context.Products
                                            where p.Height == height
                                            select p).Skip(pageSize * (pageNum - 1))
                                               .Take(pageSize)
                                               .Include(nameof(Product.Category))
                                               .ToListAsync();
            products = products.OrderBy(p => p.Height)
                                       .ThenBy(p => p.Width)
                                       .ThenBy(p => p.Length)
                                       .ThenBy(p => p.Category[1].CategoryName)
                                       .ThenBy(p => p.Category[0].CategoryName).ToList();
            return products;
        }

        public static async Task<Product> Update(ApplicationDbContext _context, Product p)
        {
            _context.Entry(p).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return p;
        }

        public static async Task<int> GetTotalProductsAsync(ApplicationDbContext _context)
        {
            return await (from p in _context.Products
                          select p).CountAsync();
        }

        public static async Task<int> GetTotalProductsAsync(ApplicationDbContext _context, byte height)
        {
            return await (from p in _context.Products
                          where p.Height == height
                          select p).CountAsync();
        }

        public static async Task<int> GetTotalProductsAsync(ApplicationDbContext _context, byte height, byte width)
        {
            return await (from p in _context.Products
                          where p.Height == height && p.Width == width
                          select p).CountAsync();
        }

        public static async Task<int> GetTotalProductsAsync(ApplicationDbContext _context, byte height, byte width, byte length)
        {
            return await (from p in _context.Products
                          where p.Height == height && p.Width == width && p.Length == length
                          select p).CountAsync();
        }

        public static async Task<int> GetTotalProductsAsync(ApplicationDbContext _context, byte height, byte width, byte length, string category)
        {
            List<Product> products = await (from p in _context.Products
                                      where p.Height == height && p.Width == width && p.Length == length
                                      select p).Include(nameof(Product.Category)).ToListAsync();
            List<Product> newProducts = new List<Product>();
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Category[0].CategoryName == category)
                {
                    newProducts.Add(products[i]);
                }
            }
            return newProducts.Count;
        }

        public static async Task<int> GetTotalProductsAsync(ApplicationDbContext _context, byte height, byte width, byte length, string category, string treatmentType)
        {
            List<Product> products = await (from p in _context.Products
                                            where p.Height == height && p.Width == width && p.Length == length
                                            select p).Include(nameof(Product.Category)).ToListAsync();
            List<Product> newProducts = new List<Product>();
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Category[0].CategoryName == category && products[i].Category[1].CategoryName == treatmentType)
                {
                    newProducts.Add(products[i]);
                }
            }
            return newProducts.Count;
        }

        public static bool CheckForExistingProduct(ApplicationDbContext _context, Product p)
        {
            List<Product> product = (from prod in _context.Products
                                     where prod.Height == p.Height
                                     && prod.Width == p.Width
                                     && prod.Length == p.Length
                                     select prod).Include(c => c.Category).ToList();
            for (int i = 0; i < product.Count; i++)
            {
                for (int j = 0; j < p.Category.Count; j++)
                {
                    if (product[i].Category[j].CategoryID == p.Category[j].CategoryID)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static async Task<List<byte>> GetHeightAsync(ApplicationDbContext _context)
        {
            List<byte> height =  await (from p in _context.Products
                          select p.Height).Distinct().ToListAsync();
            return height;
        }

        public static async Task<List<byte>> GetWidthAsync(ApplicationDbContext _context, byte height)
        {
            List<byte> width = await (from p in _context.Products
                                      where p.Height == height
                                      select p.Width).Distinct().ToListAsync();
            return width;
        }

        public static async Task<List<byte>> GetLengthAsync(ApplicationDbContext _context, byte height, byte width)
        {
            return await (from p in _context.Products
                          where p.Height == height && p.Width == width
                          select p.Length).Distinct().ToListAsync();
        }
    }
}
