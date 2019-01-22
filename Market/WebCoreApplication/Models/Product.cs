using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreApplication.Models
{
    public class Product
    {
        public Product()
        {
            
        }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public Product(string name, decimal price, string category): this(name, price)
        {
            Category = category;
        }

        public Product(int id, string name, decimal price, string category): this(name, price, category)
        {
            ProductId = id;
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public override string ToString()
        {
            return $"{Name} {Price}";
        }
    }
}
