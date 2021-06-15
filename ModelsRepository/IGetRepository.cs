using System.Collections.Generic;

namespace Cine.ModelsRepository
{
    public interface IGetRepository<T> : ICrudReposiroty<T>
    {
        T GetObj(int? id);
        IEnumerable<T> GetAllObj();
    }
}