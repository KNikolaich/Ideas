using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace WebCoreApplication.Models
{
    public class Product : PersistentObj
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
            Id = id;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите описание")]
        public string Description { get; set; }
        [Required, Range(0.01, double.MaxValue, ErrorMessage = "Введите цену")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Укажите категорию")]
        public string Category { get; set; }

        public override string ToString()
        {
            return $"{Name} {Price}";
        }
    }
}
