using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine.Models;

namespace Cine.ModelsRepository
{
    public interface ICrudReposiroty<T>
    {
        void Add(T obj);
        void Update(T obj);
    }
}