using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine.Tools
{
    public class GenericPaginator<T> where T : class
    {
        public int ActualPage { get; set; }
        public int RegistrysPerPage { get; set; }
        public int TotalRegistrys { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<T> Result { get; set; }
    }
}
