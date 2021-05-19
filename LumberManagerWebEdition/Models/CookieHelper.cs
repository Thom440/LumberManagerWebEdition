using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LumberManagerWebEdition.Models
{
    public class CookieHelper
    {
        const string CartCookie = "CartCookie";

        public static List<Product> GetCartProducts(IHttpContextAccessor http)
        {
            string existingItems = http.HttpContext.Request.Cookies[CartCookie];

            List<Product> cartProducts = new List<Product>();

            if (existingItems != null)
            {
                cartProducts = JsonConvert.DeserializeObject<List<Product>>(existingItems);
            }

            return cartProducts;
        }

        public static void AddProductToCart(IHttpContextAccessor http, Product p)
        {
            List<Product> cartProducts = GetCartProducts(http);

            cartProducts.Add(p);
            string data = JsonConvert.SerializeObject(cartProducts, new JsonSerializerSettings() 
            { 
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            CookieOptions options = new CookieOptions()
            {
                Expires = DateTime.Now.AddYears(1),
                Secure = true,
                IsEssential = true
            };

            http.HttpContext.Response.Cookies.Append(CartCookie, data, options);
        }

        public static int GetTotalCartProducts(IHttpContextAccessor http)
        {
            List<Product> cartProducts = GetCartProducts(http);
            return cartProducts.Count;
        }
    }
}
