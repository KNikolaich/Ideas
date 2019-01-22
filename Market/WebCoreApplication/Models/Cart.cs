using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreApplication.Models
{
    public class Cart
    {
        private List<CartLine> lines = new List<CartLine>();
        public virtual void AddItem(Product product, int quantity)
        {
            CartLine line = lines.Where(p => p.Product.ProductId == product.ProductId).FirstOrDefault();
            if (line == null)
            {
                lines.Add(new CartLine
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

        public virtual void RemoveLine(Product product) => lines.RemoveAll(l => l.Product.ProductId == product.ProductId);

        public virtual decimal ComputeTotalValue() => lines.Sum(e => e.Product.Price * e.Quantity);

        public virtual void Clear() => lines.Clear();

        public virtual IEnumerable<CartLine> Lines => lines;
    }
}
