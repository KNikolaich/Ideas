using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCoreApplication.Components;
using WebCoreApplication.Models;
using WebCoreApplication.Models.ViewModel;

namespace WebCoreApplication.Controllers
{
    /// <summary>    контроллер продуктов    </summary>
    public class ProductController : ReposBaseController
    {
        public int PageSize = 4;

        public ProductController(IProductRepository repo)
        {
            ProductRepository = repo;
        }

        public ViewResult List(string category, int page = 1)
        {
            var resultP = ProductRepository.Products.
                Where(p=> category == null || p.Category == category).
                OrderBy(p => p.ProductId).
                Skip((page - 1) * PageSize).
                Take(PageSize);
            
            return View(new ProductsListViewModel{
                Products = resultP,
                Paginginfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? ProductRepository.Products.Count() : ProductRepository.Products.Where(e=>e.Category == category).Count()
                },
                CurrentCategory = category
            });
        }
    }
}