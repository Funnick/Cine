using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Cine.Models;
using Cine.ModelsRepository;

namespace Cine.SQLiteRepository
{
    public class DbDiscountRepository : IGetRepository<Discount>
    {
        private readonly CineDbContext _context;
        
        public DbDiscountRepository(CineDbContext context)
        {
            _context = context;
        }
        
        public void Add(Discount obj)
        {
            _context.Discounts.Add(obj);
            _context.SaveChanges();
        }

        public Discount GetObj(int id)
        {
            return _context.Discounts.Find(id);
        }

        public IEnumerable<Discount> GetAllObj()
        {
            return _context.Discounts;
        }
    }
}