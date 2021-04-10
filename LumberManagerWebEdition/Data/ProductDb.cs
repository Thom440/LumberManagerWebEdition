using LumberManagerWebEdition.Models;
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
    }
}
