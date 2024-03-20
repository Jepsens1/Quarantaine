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

        public void CreateUser(UserModel obj)
        {
            db.Create(obj);
        }
        public UserModel GetUser(UserModel obj)
        {
            return db.Read(obj);
        }
        public void UpdateUser(UserModel obj)
        {
            db.Update(obj);
        }
        public void DeleteUser(UserModel obj)
        {
            db.Delete(obj);
        }
        public UserModel GetUserById(int id)
        {
            return db.GetById(id);
        }
    }
}
