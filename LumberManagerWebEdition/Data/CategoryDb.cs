using LumberManagerWebEdition.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LumberManagerWebEdition.Data
{
    public class CategoryDb
    {
        public static Category GetCategory(ApplicationDbContext _context, int id)
        {
            Category category = (from c in _context.Categories
                                 where c.CategoryID == id
                                 select c).Single();
            return category;
        }

        public static async Task<List<Category>> GetCategoryAsync(ApplicationDbContext _context, byte height, byte width, byte length)
        {
            List<Product> products = await (from p in _context.Products
                                            where p.Height == height && p.Width == width && p.Length == length
                                            select p).Include(nameof(Product.Category)).ToListAsync();

            return (from p in products
                    select p.Category[0]).Distinct().ToList();
        }

        public static async Task<List<Category>> GetTypeAsync(ApplicationDbContext _context, byte height, byte width, byte length, string category)
        {
            List<Product> products = await (from p in _context.Products
                                            where p.Height == height && p.Width == width && p.Length == length
                                            select p).Include(nameof(Product.Category)).ToListAsync();

            List<Category> categories = new List<Category>();
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Category[0].CategoryName == category)
                {
                    categories.Add(products[i].Category[1]);
                }
            }
            return categories;
        }
    }
}
