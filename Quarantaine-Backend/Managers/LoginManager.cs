using Quarantaine_Backend.Interfaces;
using Quarantaine_Backend.Models;
using Quarantaine_Backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarantaine_Backend.Managers
{
    public class LoginManager
    {
        private IDatabase<UserModel> db;

        public LoginManager(IDatabase<UserModel> database)
        {
            db = database;
        }

        public UserModel Login(string username, string password)
        {
            UserModel user = db.GetByLogin(username, password);
            if (user == null)
            {
                return null;
            }
            if (!EncryptionService.VerifyPassword(password, user.Password, user.HashSalt.Salt))
            {
                return null;
            }
            HashSaltModel newHashSalt = EncryptionService.SaltPassword(user.Password);
            user.HashSalt = newHashSalt;
            db.Update(user);
            return user;
        }

        public void CreateAccount(string username, string password)
        {
            HashSaltModel hashSalt = EncryptionService.SaltPassword(password);
            UserModel user = new UserModel(username, password, hashSalt);
            db.Create(user);
        }
    }
}
