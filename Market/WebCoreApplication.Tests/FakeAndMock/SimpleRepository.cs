using System.Collections.Generic;
using WebCoreApplication.Models;

namespace WebCoreApplication.Tests.FakeAndMock
{
    public class SimpleRepository //: IProductRepository
    {
        private readonly Dictionary<string, Product> _products = new Dictionary<string, Product>();

        public static SimpleRepository SharedRepository { get; } = new SimpleRepository();

        private SimpleRepository()
        {
            var initItems = new[]
            {
                new Product("Kayak", 275M),
                new Product("Lifejacket", 48.95M),
                new Product("Soccer nall", 19.5M),
                new Product("Cornet flag", 34.95M),
                new Product("Clock on wall", 11.5M),
                new Product("Lamp on table", 5.75M),
            };
            foreach (var item in initItems)
            {
                AddProduct(item);
            }
            //_products.Add("Error", null);
        }


        #region Implementation from Interface

        public IEnumerable<Product> Products => _products.Values;
        public void SaveProduct(Product product)
        {
            throw new System.NotImplementedException();
        }

        public void AddProduct(Product item)
        {
            _products.Add(item.Name, item);
        }

        #endregion
    }
}
