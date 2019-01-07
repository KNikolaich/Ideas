using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCoreApplication.Components;
using WebCoreApplication.Models;

namespace WebCoreApplication.Controllers
{
    public class HomeController : ReposBaseController
    {
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
            //Repository.AddProduct(p);
            return RedirectToAction("Index");
        }

    }
}