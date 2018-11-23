using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreApplication.Models
{
    public class FakeRepository : IRepository
    {
        public IEnumerable<Product> Products => new[]
        {
            new Product("Kayak", 275M),
            new Product("Lifejacket", 48.95M),
            new Product("Soccer nall", 19.5M),
            new Product("Cornet flag", 34.95M),
            new Product("Clock on wall", 11.5M),
            new Product("Lamp on table", 5.75M),
        };

        public void AddProduct(Product item)
        {
            throw new NotImplementedException();
        }
    }
}
