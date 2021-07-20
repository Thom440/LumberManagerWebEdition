using LumberManagerWebEdition.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LumberManagerWebEdition.Data
{
    public static class OrderLineItemsDB
    {
        /// <summary>
        /// Adds the line item to order
        /// </summary>
        /// <param name="orderLineItems">The line items to be added</param>
        public static void AddOrderLineItem(ApplicationDbContext _context, OrderLineItems orderLineItems)
        {
            _context.OrderLineItems.Add(orderLineItems);
            _context.SaveChanges();
        }
    }
}
