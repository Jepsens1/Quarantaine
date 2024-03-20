using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quarantaine_Backend.Interfaces;
using Quarantaine_Backend.Models;

namespace Quarantaine_Backend.Data_Access
{
    public class MssqlDB : IDatabase<T>
    {

        public virtual void Create(T obj)
        {

        }
        public virtual UserModel Read(T obj)
        {
            return null;
        }
        public virtual void Update(T obj)
        {

        }
        public virtual void Delete(T obj)
        {

        }
        public virtual UserModel GetById(int id)
        {
            return null;
        }
        public UserModel GetByLogin(string name, string password)
        {
            return null;
        }
    }
}
