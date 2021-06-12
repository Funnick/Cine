using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Cine.Models;
using Cine.ModelsRepository;

namespace Cine.SQLiteRepository
{
    public class DbShowRepository : IGetRepository<Show>
    {
        private readonly CineDbContext _context;
        
        public DbShowRepository(CineDbContext context)
        {
            _context = context;
        }
        
        public void Add(Show obj)
        {
            _context.Shows.Add(obj);
            _context.SaveChanges();
        }

        public Show GetObj(int id)
        {
            return _context.Shows.Find(id);
        }

        public IEnumerable<Show> GetAllObj()
        {
            return _context.Shows;
        }
    }
}