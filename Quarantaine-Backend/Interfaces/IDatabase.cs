using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarantaine_Backend.Interfaces
{
    public interface IDatabase<T>
    {
        public void Create(T obj);
        public T Read(T obj);
        public void Update(T obj);
        public void Delete(T obj);
        public T GetById(int id);
    }
}
