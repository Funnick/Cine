using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Cine.Models;
using Cine.ModelsRepository;

namespace Cine.SQLiteRepository
{
    public class DbTicketRepository : IGetRepository<Ticket>
    {
        private readonly CineDbContext _context;
        
        public DbTicketRepository(CineDbContext context)
        {
            _context = context;
        }
        
        public void Add(Ticket obj)
        {
            _context.Tickets.Add(obj);
            _context.SaveChanges();
        }

        public Ticket GetObj(int id)
        {
            return _context.Tickets.Find(id);
        }

        public IEnumerable<Ticket> GetAllObj()
        {
            return _context.Tickets;
        }
    }
}