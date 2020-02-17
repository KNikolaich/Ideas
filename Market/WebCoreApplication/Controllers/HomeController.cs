using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebCoreApplication.Components;
using WebCoreApplication.Models;

namespace WebCoreApplication.Controllers
{
    public class HomeController : ReposBaseController
    {

        public HomeController(IProductRepository repo)
        {
            _repository = repo;
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Приветствую тебя, мой мир!";
            return View(_repository.Products.OrderBy(p=>p.Name));
        }

        [HttpGet]
        public IActionResult AddProduct() => View(new Product());

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            //ProductRepository.AddProduct(p);
            return RedirectToAction("Index");
        }

    }
}