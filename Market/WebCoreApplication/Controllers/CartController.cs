using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebCoreApplication.Components;
using WebCoreApplication.Models;
using WebCoreApplication.Models.ViewModel;

namespace WebCoreApplication.Controllers
{
    public class CartController : ReposBaseController
    {
        private Cart _cart;

        public CartController(IProductRepository repository, Cart cartService)
        {
            _repository = repository;
            _cart = cartService;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel { Cart = _cart, ReturnUrl = returnUrl });
        }

        public RedirectToActionResult AddToCart(int productid, string returnUrl)
        {
            Product product = _repository.Products
            .FirstOrDefault(p => p.ProductId == productid);
            if (product != null)
            {
                _cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productid, string returnUrl)
        {
            Product product = _repository.Products.FirstOrDefault(p => p.ProductId == productid);
            if (product != null)
            {
                _cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}