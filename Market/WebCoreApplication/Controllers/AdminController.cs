using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using WebCoreApplication.Components;
using WebCoreApplication.Models;

namespace WebCoreApplication.Controllers
{
    public class AdminController : ReposBaseController
    {
        public AdminController(IProductRepository repo)
        {
            _repository = repo;
        }

        public IActionResult Index()
        {
            return View(_repository.Products);
        }

        public IActionResult Edit(int id)
        {
            return View(_repository.Products.FirstOrDefault(p=>p.Id == id));
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} был сохранен";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ViewResult Create() => View("Edit", new Product());

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var delPro = _repository.DeleteProduct(id);
            if (delPro != null)
            {
                TempData["message"] = $"{delPro.Name} был уничножен";
            }
            return RedirectToAction("Index");
        }
    }
}