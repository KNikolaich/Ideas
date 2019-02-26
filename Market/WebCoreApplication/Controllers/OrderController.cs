using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCoreApplication.Models;

namespace WebCoreApplication.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository _oRepos;
        private Cart _cart;

        public OrderController(IOrderRepository repository, Cart cart)
        {
            _oRepos = repository;
            _cart = cart;
        }

        public ViewResult Checkout()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if(!_cart.Lines.Any())
            {
                ModelState.AddModelError("", "Пардон, но корзина то пуста!");
            }
            if (ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToArray();
                _oRepos.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            return View(order);
        }

        public ViewResult Completed()
        {
            _cart.Clear();
            return View();
        }
    }
}