using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ConfigurationController : Controller
    {
        // GET: Configuration
        public ActionResult Index()
        {
            ViewData["Message"] = "Сообщение с модели.";
            return View();
        }
        
        // GET: Configuration/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Configuration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Configuration/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Configuration/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["Message"] = "Сообщение с модели.";
            return View(new ConfigurationEditModel() { Message = "Сообщение с модели" });
        }

        // POST: Configuration/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Configuration/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Configuration/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}