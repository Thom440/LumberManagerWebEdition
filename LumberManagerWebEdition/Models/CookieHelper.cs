﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
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

        public static List<ProductCookieHelper> GetCartProducts(IHttpContextAccessor http)
        {
            string existingItems = http.HttpContext.Request.Cookies[CartCookie];

            List<ProductCookieHelper> cartProducts = new List<ProductCookieHelper>();

            if (existingItems != null)
            {
                cartProducts = JsonConvert.DeserializeObject<List<ProductCookieHelper>>(existingItems);
            }

            return cartProducts;
        }

        public static void AddProductToCart(IHttpContextAccessor http, Product p, byte quantity)
        {
            List<ProductCookieHelper> cartProducts = GetCartProducts(http);

            ProductCookieHelper product = new ProductCookieHelper();
            product.ProductID = p.ProductID;
            product.Quantity = quantity;

            for (int i = 0; i < cartProducts.Count; i++)
            {
                if (cartProducts[i].ProductID == product.ProductID && cartProducts[i].Quantity == quantity)
                {
                    return;
                }
                else if (cartProducts[i].ProductID == product.ProductID && cartProducts[i].Quantity != quantity)
                {
                    cartProducts = DeleteCartProducts(http, product.ProductID);
                }
            }

            cartProducts.Add(product);
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

        public static List<ProductCookieHelper> DeleteCartProducts(IHttpContextAccessor http, int id)
        {
            List<ProductCookieHelper> cartProducts = GetCartProducts(http);
            cartProducts = cartProducts.Where(p => p.ProductID != id).ToList();
            string data = JsonConvert.SerializeObject(cartProducts, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            http.HttpContext.Response.Cookies.Append(CartCookie, data);
            return cartProducts;
        }

        public static int GetTotalCartProducts(IHttpContextAccessor http)
        {
            List<ProductCookieHelper> cartProducts = GetCartProducts(http);

            int total = 0;
            foreach (ProductCookieHelper totalProducts in cartProducts)
            {
                total += totalProducts.Quantity;
            }

            return total;
        }
    }
}
