using System.Collections.Generic;
using System.Linq;

namespace WebCoreApplication.Models
{
    public class EfProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public EfProductRepository(AppDbContext contxt)
        {
            _context = contxt;
        }

        public IEnumerable<Product> Products => _context.Products;

        public void SaveProduct(Product product)
        {
            if (product.Id == 0)
            {
                _context.Products.Add(product);
            }
            else
            {
                var dbEntry = _context.Products.FirstOrDefault(p => p.Id == product.Id);
                if (dbEntry != null)
                {
                    product.CopyTo(dbEntry);
                }
            }
            _context.SaveChanges();
        }
    }
}
