using LumberManagerWebEdition.Models;
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
    }
}
