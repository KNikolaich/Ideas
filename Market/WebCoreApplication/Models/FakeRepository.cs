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
            new Product("Fake Kayak", 275M),
            new Product("Fake Lifejacket", 48.95M),
            new Product("Fake Soccer nall", 19.5M),
            new Product("Fake Cornet flag", 34.95M),
            new Product("Fake Clock on wall", 11.5M),
            new Product("Fake Lamp on table", 5.75M)
        };

        public void AddProduct(Product item)
        {
            throw new NotImplementedException();
        }
    }
}
