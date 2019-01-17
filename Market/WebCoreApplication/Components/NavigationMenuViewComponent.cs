using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApplication.Models;

namespace WebCoreApplication.Components
{
    /// <summary>
    /// компонент навигационного меню
    /// </summary>
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IRepository repository;

        public NavigationMenuViewComponent(IRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
