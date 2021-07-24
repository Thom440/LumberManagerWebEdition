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

        public IActionResult ViewOrder(string userId, int orderId)
        {
            List<OrderLineItems> orderLineItems = OrderLineItemsDB.GetOrderLineItems(_context, orderId);
            User user = UserDB.GetUser(_context, userId);
            Order order = OrderDB.GetOrder(_context, orderId);
            ViewData["Order"] = order;
            ViewData["User"] = user;
            ViewData["LineItems"] = orderLineItems;
            return View();
        }
    }
}
