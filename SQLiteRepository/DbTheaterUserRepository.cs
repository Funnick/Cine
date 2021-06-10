using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine.Models;
using Cine.ModelsRepository;

namespace Cine.SQLiteRepository
{
    public class DbTheaterUserRepository : ITheaterUserRepository
    {
        private readonly CineDbContext _context;
        
        public DbTheaterUserRepository(CineDbContext context)
        {
            _context = context;
        }
        
        /*public async Task<TheaterUser> Add(TheaterUser theaterUser)
        {
            return thearterUser;
            
        }*/

        public TheaterUser GetTheaterUser(string theaterUserId)
        {
            return _context.TheaterUsers.Find(theaterUserId);
        }

        public IEnumerable<TheaterUser> GetAllTheaterUser()
        {
            return _context.TheaterUsers;
        }
    }
}