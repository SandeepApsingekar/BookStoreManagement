using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Service
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll(string name = null);
        T GetById(int id);
        T GetByName(string name);
        void Create(T obj);
        void Delete(T obj);
    }
}
