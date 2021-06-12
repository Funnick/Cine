using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine.Models;

namespace Cine.ModelsRepository
{
    public interface ITheaterMemberRepository
    {
        void Add(TheaterUser theaterUser);
        TheaterMember GetTheaterMember(string theaterUserId);
        IEnumerable<TheaterMember> GetAllTheaterMembers();
    }
}