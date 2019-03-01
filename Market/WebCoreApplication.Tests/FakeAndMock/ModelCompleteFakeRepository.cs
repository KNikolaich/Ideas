using System;
using System.Collections.Generic;
using System.Linq;
using WebCoreApplication.Models;

namespace WebCoreApplication.Tests.FakeAndMock
{
    public class ModelCompleteFakeRepository : IProductRepository
    {
        private List<Product> _products;
        private static Func<Product, bool> _func = product => true;

        public ModelCompleteFakeRepository()
        {
            if(Products != null)
            {
                _products = GetFakeNewList();
            }
        }

        private static List<Product> GetFakeNewList()
        {
            return new List<Product>
            {
                new Product(1, "Kayak", 275M, "Cat1"),
                new Product(2,"Lifejacket", 48.95M, "Cat1"),
                new Product(3,"Soccer nall", 19.5M, "Cat2"),
                new Product(4,"Cornet flag", 34.95M, "Cat1"),
                new Product(5,"Clock on wall", 11.5M, "Cat2"),
                new Product(6,"Lamp on table", 5.75M, "Cat3")
            }.Where(_func).ToList();
        }

        public ModelCompleteFakeRepository(IEnumerable<Product> products)
        {
            _products = products?.ToList();
        }

        public ModelCompleteFakeRepository(Func<Product, bool> productsFunc)
        {
            _func = productsFunc;
            if (Products != null)
            {
                _products = GetFakeNewList();
            }
        }

        public void AddProduct(Product item)
        {
            if (Products != null)
            {
                _products.Add(item);
            }
        }

        public IEnumerable<Product> Products => _products ?? (_products = new List<Product>());
        public void SaveProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
