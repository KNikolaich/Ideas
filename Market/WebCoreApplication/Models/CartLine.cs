using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreApplication.Models
{
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }
}
