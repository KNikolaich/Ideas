using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebCoreApplication.Models
{
    /// <summary> реализация интерфейса репозитория ордета </summary>
    public class EfOrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public EfOrderRepository(AppDbContext cont)
        {
            _context = cont;
        }

        public IEnumerable<Order> Orders => _context.Orders
            .Include(o => o.Lines)
            .ThenInclude(l => l.Product);

        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.Lines);
            if (order.Id == 0)
            {
                _context.Attach(order);
            }
            _context.SaveChanges(); 
        }
    }
}
