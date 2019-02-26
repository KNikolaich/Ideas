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
        public ViewResult Checkout()
        {
            return View(new Order());
        }
    }
}