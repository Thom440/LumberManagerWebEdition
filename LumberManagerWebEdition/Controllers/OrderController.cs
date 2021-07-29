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

        public IActionResult Index(string id, int orderid)
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

        [HttpGet]
        public IActionResult SetShipDate(int orderId)
        {
            Order order = OrderDB.GetOrder(_context, orderId);
            User user = order.Customers[0];
            DateTime date = DateTime.Now;
            ViewData["User"] = user;
            ViewData["Order"] = order;
            ViewData["Date"] = date;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SetShipDate(string user, int order, string date)
        {
            DateTime parsedDate = DateTime.Parse(date);

            Order thisOrder = OrderDB.GetOrder(_context, order);

            if (parsedDate > DateTime.Now || parsedDate < thisOrder.InvoiceDate)
            {
                TempData["Error"] = "Date cannot be older than Order Date or in the future";
                ViewData["User"] = UserDB.GetUser(_context, user);
                ViewData["Order"] = OrderDB.GetOrder(_context, order);
                ViewData["date"] = DateTime.Now;
                return View(thisOrder.OrderID);
            }

            thisOrder.ShipDate = parsedDate;

            await OrderDB.UpdateOrderAsync(_context, thisOrder);

            return RedirectToAction("Index");
        }
    }
}
