using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreApplication.Models
{
    public interface IRepository
    {
        IEnumerable<Product> Products { get; }

        void AddProduct(Product item);
    }
}
