using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Pages;

namespace WebApplication2.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index(string idLpu)
        {
            return View("Index");
        }

        public IActionResult Result(BookMedServModel bookMedServ)
        {
           

            return View(bookMedServ);
        }
    }
}