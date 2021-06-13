using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Cine.Models;
using Cine.ModelsRepository;

namespace Cine.SQLiteRepository
{
    public class DbCinemaRepository : IGetRepository<Cinema>
    {
        private readonly CineDbContext _context;
        
        public DbCinemaRepository(CineDbContext context)
        {
            _context = context;
        }
        
        public void Add(Cinema obj)
        {
            _context.Cinemas.Add(obj);
            _context.SaveChanges();
        }

        public void Update(Cinema obj)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(c => c.CinemaId == obj.CinemaId);
            if (cinema != null)
            {
                cinema.NumberOfSeats = obj.NumberOfSeats;
            }
            _context.SaveChanges();
        }

        public Cinema GetObj(int id)
        {
            return _context.Cinemas.Find(id);
        }

        public IEnumerable<Cinema> GetAllObj()
        {
            return _context.Cinemas;
        }
    }
}