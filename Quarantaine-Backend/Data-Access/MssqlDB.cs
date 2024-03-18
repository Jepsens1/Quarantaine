using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quarantaine_Backend.Interfaces;
using Quarantaine_Backend.Models;

namespace Quarantaine_Backend.Data_Access
{
    public class MssqlDB : IDatabase<UserModel>
    {
        private string connectString;

        public virtual void Create(UserModel obj)
        {

        }
        public virtual UserModel Read(UserModel obj)
        {
            return null;
        }
        public virtual void Update(UserModel obj)
        {

        }
        public virtual void Delete(UserModel obj)
        {

        }
        public virtual UserModel GetById(int id)
        {
            return null;
        }
        public virtual UserModel GetByLogin(string name, string password)
        {
            return null;
        }
    }
}
