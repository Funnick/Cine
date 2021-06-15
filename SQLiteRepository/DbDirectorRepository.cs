using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Cine.Models;
using Cine.ModelsRepository;

namespace Cine.SQLiteRepository
{
    public class DbDirectorRepository : IGetRepository<Director>
    {
        private readonly CineDbContext _context;
        
        public DbDirectorRepository(CineDbContext context)
        {
            _context = context;
        }
        
        public void Add(Director obj)
        {
            _context.Directors.Add(obj);
            _context.SaveChanges();
        }

        public void Update(Director obj)
        {
            Director director = _context.Directors.FirstOrDefault(d => d.ProducerId == obj.ProducerId);
            if (director != null)
            {
                director.Name = obj.Name;
                director.Age = obj.Age;
                director.Country = obj.Country;
            }

            _context.SaveChanges();
        }

        public Director GetObj(int? id)
        {
            return _context.Directors.Find(id);
        }

        public IEnumerable<Director> GetAllObj()
        {
            return _context.Directors;
        }
    }
}