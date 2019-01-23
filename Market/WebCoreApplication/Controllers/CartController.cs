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
        private Cart _cart;

        public CartController(IProductRepository repository, Cart cartService)
        {
            ProductRepository = repository;
            _cart = cartService;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel { Cart = _cart, ReturnUrl = returnUrl });
        }

        public RedirectToActionResult AddToCart(int productid, string returnUrl)
        {
            Product product = ProductRepository.Products
            .FirstOrDefault(p => p.ProductId == productid);
            if (product != null)
            {
                _cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productid, string returnUrl)
        {
            Product product = ProductRepository.Products.FirstOrDefault(p => p.ProductId == productid);
            if (product != null)
            {
                _cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}