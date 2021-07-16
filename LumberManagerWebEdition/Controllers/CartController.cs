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
    /// <summary>
    /// A controller for the cart.
    /// Adding and changing quantities of products in the cart.
    /// </summary>
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpcontext;

        public CartController(ApplicationDbContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpcontext = httpContext;
        }

        /// <summary>
        /// Adds a product to the cart.
        /// </summary>
        /// <param name="id">Product ID to be added.</param>
        /// <param name="previousUrl">Redirect to where user was.</param>
        /// <param name="inputquantity">Amount of product to be added to cart.</param>
        public IActionResult Add(int id, string previousUrl, byte inputquantity)
        {
            Product p = ProductDb.GetProduct(_context, id);

            if (inputquantity > 0)
            {
                CookieHelper.AddProductToCart(_httpcontext, p, inputquantity);
                TempData["Message"] = p.Height + " x " + p.Width + " x " + p.Length + " " + p.Category[0] + " " + p.Category[1] + " was added successfully.";
            }
            else
            {
                bool isTrue = CookieHelper.CheckForExistingProduct(_httpcontext, id);
                CookieHelper.DeleteCartProducts(_httpcontext, id);

                if (isTrue)
                {
                    TempData["Message"] = p.Height + " x " + p.Width + " x " + p.Length + " " + p.Category[0] + " " + p.Category[1] + " was removed.";
                }
            }

            return Redirect(previousUrl);
        }

        /// <summary>
        /// View that shows the products in the cart.
        /// </summary>
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

        /// <summary>
        /// Deletes product from cart.
        /// </summary>
        /// <param name="id">Product ID.</param>
        /// <param name="previousUrl">Redirect to where user was.</param>
        /// <returns></returns>
        public IActionResult Delete(int id, string previousUrl)
        {
            CookieHelper.DeleteCartProducts(_httpcontext, id);
            return Redirect(previousUrl);
        }
    }
}
