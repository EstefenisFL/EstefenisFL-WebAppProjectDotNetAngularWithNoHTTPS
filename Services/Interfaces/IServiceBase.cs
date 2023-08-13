using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IServiceBase<T> where T : class
    {
        void Add(T obj);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Update(T obj);
        void Remove(T obj);
    }
}
