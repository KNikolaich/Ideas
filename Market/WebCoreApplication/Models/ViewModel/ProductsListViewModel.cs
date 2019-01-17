using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreApplication.Models.ViewModel
{
    /// <summary>    /// Модель представления продуктов на страницу    /// </summary>
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products {get ; set ; }
        public PagingInfo Paginginfo { get ; set; } 
        public string CurrentCategory { get; set; }
    }
}
