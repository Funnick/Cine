using System.Collections.Generic;
using Cine.Models;

namespace Cine.ModelsRepository
{
    public interface ITicketRepository : IGetRepository<Ticket>
    {
        IEnumerable<Ticket> GetShowTicekts(int showId);
    }
}