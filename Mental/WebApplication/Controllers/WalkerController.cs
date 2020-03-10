using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.Game;

namespace WebApplication.Controllers
{
    /// <summary>
    /// Контроллер бродилок
    /// </summary>
    public class WalkerController : Controller
    {
        ContextGame _db = new ContextGame();

        // GET: Walker
        public ActionResult Index()
        {
            // получаем из бд все объекты Walker
            IEnumerable<Walker> walkers = _db.Walkers;
            Walker w = walkers.FirstOrDefault();
            // передаем все объекты в динамическое свойство Walkers в ViewBag
            //ViewBag.Walkers = walkers;
            // возвращаем представление
            return View(walkers);
        }

        public ActionResult Create()
        {
            var newWalker = _db.Walkers.Create();

            return View(newWalker);
        }
    }
}