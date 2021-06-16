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
    public class DbParticipateRepository : IParticipantRepository
    {
        private readonly CineDbContext _context;

        public DbParticipateRepository(CineDbContext context)
        {
            _context = context;
        }

        public void Add(Participate obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Actor> GetActors(int MovieId)
        {
            List<int> Producersid = new List<int>();
            foreach (var id in _context.Participants.Where(x => x.MovieId == MovieId))
            {
                Producersid.Add(id.ProducerId);
            }
            return _context.Actors.Where(x => Producersid.Contains(x.ProducerId));
        }
        public IEnumerable<Director> GetDirectors(int MovieId)
        {
            List<int> Producersid = new List<int>();
            foreach (var id in _context.Participants.Where(x => x.MovieId == MovieId))
            {
                Producersid.Add(id.ProducerId);
            }
            return _context.Directors.Where(x => Producersid.Contains(x.ProducerId));
        }

        public IEnumerable<Participate> GetAllObj()
        {
            return _context.Participants;
        }


        public Participate GetObj(int? id)
        {
            return _context.Participants.Find(id);
        }

        public void Update(Participate obj)
        {
            throw new NotImplementedException();
        }
    }
}