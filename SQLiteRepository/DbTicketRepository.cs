using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Cine.Models;
using Cine.ModelsRepository;
using Microsoft.CodeAnalysis;

namespace Cine.SQLiteRepository
{
    public class DbTicketRepository : ITicketRepository
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

        public void Update(Ticket obj)
        {
            Ticket ticket = _context.Tickets.FirstOrDefault(t => t.TicketId == obj.TicketId);
            if (ticket != null)
            {
                ticket.Discount = obj.Discount;
                ticket.Price = obj.Price;
                ticket.Show = obj.Show;
                ticket.DiscountId = obj.DiscountId;
                ticket.SeatNumber = obj.SeatNumber;
            }

            _context.SaveChanges();
        }

        public Ticket GetObj(int? id)
        {
            return _context.Tickets.Find(id);
        }

        public IEnumerable<Ticket> GetAllObj()
        {
            return _context.Tickets;
        }

        public IEnumerable<Ticket> GetShowTicekts(int showId)
        {
            return _context.Tickets.Where<Ticket>(t => t.ShowId == showId);
        }

        public void Detele(int? id)
        {
            Ticket t = GetObj(id);
            _context.Tickets.Remove(t);
        }
    }
}