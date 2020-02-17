using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using WebCoreApplication.Models;

namespace WebCoreApplication.Tests.FakeAndMock
{
    public class ProductTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { GetPriceUnder50()};
            yield return new object[] { GetPriceOver50 };
        }

        public Product[] GetPriceOver50 => new[]
        {
            new Product("Lifejacket", 48.95M),
            new Product("Soccer nall", 19.5M),
            new Product("Cornet flag", 34.95M),
            new Product("Clock on wall", 11.5M),
            new Product("Lamp on table", 5.75M)
        };

        private IEnumerable<Product> GetPriceUnder50()
        {
            var prices = new [] {275, 48.95M, 19.5M, 24.95M};
            for (int i = 0; i < prices.Length; i++)
            {
                yield return new Product {Name = $"P{i + 1}", Price = prices[i]};
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
