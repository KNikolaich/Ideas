using System;
using System.Collections.Generic;
using System.Linq;
using WebCoreApplication.Models;

namespace WebCoreApplication.Tests
{
    public class ModelCompleteFakeRepository : IRepository
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
                new Product("Kayak", 275M),
                new Product("Lifejacket", 48.95M),
                new Product("Soccer nall", 19.5M),
                new Product("Cornet flag", 34.95M),
                new Product("Clock on wall", 11.5M),
                new Product("Lamp on table", 5.75M)
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
    }
}
