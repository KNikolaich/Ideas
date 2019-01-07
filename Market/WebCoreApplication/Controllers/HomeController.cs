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
        IRepository _repository;

        public IRepository Repository {
            get => _repository ?? (_repository = new FakeRepository());
            set => _repository = value;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Приветствую тебя, мой мир!";
            return View(Repository.Products.OrderBy(p=>p.Name));
        }

        [HttpGet]
        public IActionResult AddProduct() => View(new Product());

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            _repository.AddProduct(p);
            return RedirectToAction("Index");
        }

    }
}