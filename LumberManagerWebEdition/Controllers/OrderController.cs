using LumberManagerWebEdition.Data;
using LumberManagerWebEdition.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LumberManagerWebEdition.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<User> _userManager;

        public OrderController(ApplicationDbContext context, IHttpContextAccessor httpContext, UserManager<User> userManager)
        {
            _context = context;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string id, int orderid)
        {
            ViewData["Users"] = UserDB.GetAllUsers(_context);
            User user = null;


            if (id != null)
            {
                user = UserDB.GetUser(_context, id);

                List<Order> orders = user.Orders;

                ViewData["User"] = user;
                ViewData["Orders"] = orders;
                ViewData["SelectedCustomer"] = user.ContactFirstName + " " + user.ContactLastName;
            }
            else if (User.IsInRole(IdentityHelper.Customer))
            {
                string currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                user = UserDB.GetUser(_context, currentUserId);

                List<Order> orders = user.Orders;
                ViewData["Orders"] = orders;
                ViewData["User"] = user;
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
