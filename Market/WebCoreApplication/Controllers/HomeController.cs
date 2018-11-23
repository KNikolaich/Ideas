using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCoreApplication.Models;

namespace WebCoreApplication.Controllers
{
    public class HomeController : Controller
    {
        SimpleRepository repository = SimpleRepository.SharedRepository;

        public IActionResult Index()
        {
            ViewBag.Title = "Приветствую тебя, мой мир!";
            return View(repository.Products.Where(p=>p.Price>10 && p.Price <100));
        }

        [HttpGet]
        public IActionResult AddProduct() => View(new Product());

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            repository.AddProduct(p);
            return RedirectToAction("Index");
        }

    }
}