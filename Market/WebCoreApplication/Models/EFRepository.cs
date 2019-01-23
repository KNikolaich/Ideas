using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreApplication.Models
{
    public class EFRepository : IProductRepository
    {
        private AppDbContext _context;

        public EFRepository(AppDbContext contxt)
        {
            _context = contxt;
        }

        public IEnumerable<Product> Products => _context.Products;
        
    }
}
