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

        public static async Task<List<Product>> GetAllProductsAsync(ApplicationDbContext _context)
        {
            List<Product> products = await (from p in _context.Products
                                      select p).Include(nameof(Product.Category)).ToListAsync();
            products = products.OrderBy(p => p.Height)
                                       .ThenBy(p => p.Width)
                                       .ThenBy(p => p.Length)
                                       .ThenBy(p => p.Category[1].CategoryName)
                                       .ThenBy(p => p.Category[0].CategoryName).ToList();
            return products;
        }
    }
}
