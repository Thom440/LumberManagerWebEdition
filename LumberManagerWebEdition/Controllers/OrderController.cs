using LumberManagerWebEdition.Data;
using LumberManagerWebEdition.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LumberManagerWebEdition.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public OrderController(ApplicationDbContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        public IActionResult Index(string id, int orderid)
        {
            ViewData["Users"] = UserDB.GetAllUsers(_context);

            if (id != null)
            {
                User user = UserDB.GetUser(_context, id);

                string userID = user.Id;

                List<Order> orders = user.Orders;

                ViewData["User"] = user;
                ViewData["Orders"] = orders;
                ViewData["SelectedCustomer"] = user.ContactFirstName + " " + user.ContactLastName;
            }
            

            return View();
        }

        /// <summary>
        /// Displays the order selected
        /// </summary>
        /// <param name="userId">The id of the user for the order</param>
        /// <param name="orderId">The id of the order</param>
        /// <returns></returns>
        public IActionResult ViewOrder(string userId, int orderId)
        {
            List<OrderLineItems> orderLineItems = OrderLineItemsDB.GetOrderLineItems(_context, orderId);
            Order order = OrderDB.GetOrder(_context, orderId);
            User user = null;
            if (userId == null && order != null)
            {
                userId = order.Customers[0].Id;
                user = UserDB.GetUser(_context, userId);
            }
            else if (order == null)
            {
                TempData["InvalidOrderNumber"] = "Enter a valid order number";
                return RedirectToAction("Index");
            }
            else
            {
                user = UserDB.GetUser(_context, userId);
            }
            
            ViewData["Order"] = order;
            ViewData["User"] = user;
            ViewData["LineItems"] = orderLineItems;
            return View();
        }
    }
}
