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
        public ProductController(IRepository repo)
        {
            Repository = repo;
        }

        public ViewResult List() => View(Repository.Products);
    }
}