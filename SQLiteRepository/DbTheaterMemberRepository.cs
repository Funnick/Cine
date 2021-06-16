using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Cine.Models;
using Cine.ModelsRepository;

namespace Cine.SQLiteRepository
{
    public class DbTheaterMemberRepository : ITheaterMemberRepository
    {
        private readonly CineDbContext _context;
        
        public DbTheaterMemberRepository(CineDbContext context)
        {
            _context = context;
        }
        
        public void Add(TheaterUser theaterUser)
        {
            TheaterMember newMember = new TheaterMember()
            {
                Points = 0, TheaterUser = theaterUser,
                TheaterUserId = theaterUser.Id, Code=theaterUser.Id
            };
            theaterUser.TheaterMember = newMember;
            _context.SaveChanges();
        }

        public TheaterMember GetTheaterMember(string code)
        {
            return _context.TheaterMembers.Find(code);
        }

        public IEnumerable<TheaterMember> GetAllTheaterMembers()
        {
            return _context.TheaterMembers;
        }
    }
}