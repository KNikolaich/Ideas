using System.Collections.Generic;

namespace WebCoreApplication.Models
{
    public class EFRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public EFRepository(AppDbContext contxt)
        {
            _context = contxt;
        }

        public IEnumerable<Product> Products => _context.Products;
        
    }
}
