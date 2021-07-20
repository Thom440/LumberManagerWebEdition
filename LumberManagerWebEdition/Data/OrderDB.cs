using LumberManagerWebEdition.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LumberManagerWebEdition.Data
{
    public static class OrderDB
    {
        public static void AddOrder(ApplicationDbContext _context, Order o)
        {
            _context.Orders.Add(o);
            _context.Customers.Attach(o.Customers[0]);
            _context.SaveChanges();
        }
    }
}
