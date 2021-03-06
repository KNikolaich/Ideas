﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreApplication.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

        //void AddProduct(Product item);
        void SaveProduct(Product product);

        Product DeleteProduct(int id);
    }
}
