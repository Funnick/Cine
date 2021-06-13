using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Cine.Models;
using Cine.ModelsRepository;

namespace Cine.SQLiteRepository
{
    public class DbActorRepository : IGetRepository<Actor>
    {
        private readonly CineDbContext _context;
        
        public DbActorRepository(CineDbContext context)
        {
            _context = context;
        }
        
        public void Add(Actor obj)
        {
            _context.Actors.Add(obj);
            _context.SaveChanges();
        }

        public void Update(Actor obj)
        {
            Actor actor = _context.Actors.FirstOrDefault(a => a.ProducerId == obj.ProducerId);
            if (actor != null)
            {
                actor.Name = obj.Name;
                actor.Age = obj.Age;
                actor.Country = obj.Country;
                actor.Role = obj.Role;
            }

            _context.SaveChanges();
        }

        public Actor GetObj(int id)
        {
            return _context.Actors.Find(id);
        }

        public IEnumerable<Actor> GetAllObj()
        {
            return _context.Actors;
        }
    }
}