using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine.Models;

namespace Cine.ModelsRepository
{
    public interface ITheaterUserRepository
    {
        /*Task<TheaterUser> Add(TheaterUser theaterUser);*/
        TheaterUser GetTheaterUser(string theaterUserId);
        IEnumerable<TheaterUser> GetAllTheaterUser();
    }
}