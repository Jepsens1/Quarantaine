using Quarantaine_Backend.Interfaces;
using Quarantaine_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarantaine_Backend.Managers
{
    public class UserManager
    {
        private IDatabase<UserModel> db;

        public UserManager(IDatabase<UserModel> database)
        {
            db = database;
        }

        public virtual void Create(UserModel obj)
        {
            db.Create(obj);
        }
        public virtual UserModel Read(UserModel obj)
        {
            return db.Read(obj);
        }
        public virtual void Update(UserModel obj)
        {
            db.Update(obj);
        }
        public virtual void Delete(UserModel obj)
        {
            db.Delete(obj);
        }
        public virtual UserModel GetById(int id)
        {
            return db.GetById(id);
        }
    }
}
