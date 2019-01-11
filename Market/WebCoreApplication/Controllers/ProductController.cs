using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCoreApplication.Components;
using WebCoreApplication.Models;

namespace WebCoreApplication.Controllers
{
    public class ProductController : ReposBaseController
    {
        public int PageSize = 4;

        public ProductController(IRepository repo)
        {
            Repository = repo;
        }

        public ViewResult List(int page = 1)
        {
            var resultP = Repository.Products.OrderBy(p => p.ProductId).Skip((page - 1) * PageSize).Take(PageSize);
            return View(resultP);
        }
    }
}