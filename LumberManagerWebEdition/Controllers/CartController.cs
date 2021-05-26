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
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpcontext;

        public CartController(ApplicationDbContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpcontext = httpContext;
        }

        public IActionResult Add(int id, string previousUrl)
        {
            Product p = ProductDb.GetProduct(_context, id);

            CookieHelper.AddProductToCart(_httpcontext, p);

            TempData["Message"] = p.Height + " x " + p.Width + " x " + p.Length + " " + p.Category[0] + " " + p.Category[1] + " was added successfully.";

            return Redirect(previousUrl);
        }

        public IActionResult Summary()
        {
            List<Product> cartProducts = CookieHelper.GetCartProducts(_httpcontext);
            return View(cartProducts);
        }
    }
}
