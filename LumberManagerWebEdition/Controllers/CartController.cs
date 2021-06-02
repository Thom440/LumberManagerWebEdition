using LumberManagerWebEdition.Data;
using LumberManagerWebEdition.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

        public IActionResult Add(int id, string previousUrl, byte inputquantity)
        {
            //byte quantity = Convert.ToByte(inputquantity);

            Product p = ProductDb.GetProduct(_context, id);

            CookieHelper.AddProductToCart(_httpcontext, p, inputquantity);

            TempData["Message"] = p.Height + " x " + p.Width + " x " + p.Length + " " + p.Category[0] + " " + p.Category[1] + " was added successfully.";

            return Redirect(previousUrl);
        }

        public IActionResult Summary()
        {
            List<ProductCookieHelper> cartProducts = CookieHelper.GetCartProducts(_httpcontext);
            List<Product> products = new List<Product>();
            List<int> quantity = new List<int>();
            for (int i = 0; i < cartProducts.Count; i++)
            {
                products.Add(ProductDb.GetProduct(_context, cartProducts[i].ProductID));
                quantity.Add(cartProducts[i].Quantity);
            }
            ViewData["Quantity"] = quantity;
            return View(products);
        }

        public IActionResult Delete(int id, string previousUrl)
        {
            CookieHelper.DeleteCartProducts(_httpcontext, id);
            return Redirect(previousUrl);
        }
    }
}
