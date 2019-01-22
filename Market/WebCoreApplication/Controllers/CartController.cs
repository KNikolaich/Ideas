using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebCoreApplication.Components;
using WebCoreApplication.Models;
using WebCoreApplication.Infrastructure;
using WebCoreApplication.Models.ViewModel;

namespace WebCoreApplication.Controllers
{
    public class CartController : ReposBaseController
    {
        public CartController(IRepository repository)
        {
            Repository = repository;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl });
        }

        public RedirectToActionResult AddToCart(int productid, string returnUrl)
        {
            Product product = Repository.Products
            .FirstOrDefault(p => p.ProductId == productid);
            if (product != null)
            {
                Cart cart = GetCart();
                cart.AddItem(product, 1);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productid, string returnUrl)
        {
            Product product = Repository.Products.FirstOrDefault(p => p.ProductId == productid);
            if (product != null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(product);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }
        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);

        }
    }
}