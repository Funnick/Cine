using System.Collections.Generic;
using Cine.Models;

namespace Cine.ModelsRepository
{
    public interface IParticipantRepository : IGetRepository<Participate>
    {
        IEnumerable<Actor> GetActors(int MovieId);
        IEnumerable<Director> GetDirectors(int MovieId);

    }
}
