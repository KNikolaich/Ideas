using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebCoreApplication.Models
{
    [Serializable]
    public class Order
    {
        [BindNever] // атрибут заставляет систему игнорировать это свойство , и не биндить к ней контролов
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите имя"), DisplayName("имя")]
        public string Name { get; set; }

        [DisplayName("Отгружено")]
        public bool Shipped { get; set; }

        [BindNever]
        public ICollection<CartLine> Lines { get; set; }

        [Required(ErrorMessage = "Введите первую строку адреса"), DisplayName("Линия 1")]
        public string Line1 { get; set; }
        [DisplayName("Линия 2")]
        public string Line2 { get; set; }
        [DisplayName("Линия 3")]
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Введите город"), DisplayName("Город")]
        public string City { get; set; }

        [Required(ErrorMessage = "Введите область"), DisplayName("Область")]
        public string State { get; set; }

        [DisplayName("Индекс")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Введите страну"), DisplayName("Страна")]
        public string Country { get; set; }

        [DisplayName("Подарочная упаковка")]
        public bool GiftWrap { get; set; }


        public override string ToString()
        {
            return $"{Name} ";
        }
    }
}
