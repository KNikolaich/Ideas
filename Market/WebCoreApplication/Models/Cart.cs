using System.Collections.Generic;
using System.Linq;

namespace WebCoreApplication.Models
{
    public class Cart
    {
        private readonly List<CartLine> _lines = new List<CartLine>();
        public virtual void AddItem(Product product, int quantity)
        {
            CartLine line = _lines.FirstOrDefault(p => p.Product.ProductId == product.ProductId);
            if (line == null)
            {
                _lines.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Product product) => _lines.RemoveAll(l => l.Product.ProductId == product.ProductId);

        public virtual decimal ComputeTotalValue() => _lines.Sum(e => e.Product.Price * e.Quantity);

        public virtual void Clear() => _lines.Clear();

        public virtual IEnumerable<CartLine> Lines => _lines;
    }
}
