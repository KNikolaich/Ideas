using Microsoft.EntityFrameworkCore;

namespace WebCoreApplication.Models
{
    /// <summary>
    /// Шлюз к контексту EF core
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartLine> CartLines { get; set; }
    }
}