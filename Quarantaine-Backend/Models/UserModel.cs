using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarantaine_Backend.Models
{
    public struct Position
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
    public struct Area
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double W { get; set; }
        public double H { get; set; }

    }
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Password { get; private set; }
        public HashSaltModel HashSalt { get; set; }
        public bool IsQuarantine { get; set; }
        public Area IsolationArea { get; set; }
        public Position CurrentPosition { get; set; }
        public AlarmState LastAlarmState { get; set; }
        public bool AlarmIsOn { get; set; }

        public UserModel(string name, string lastName, string password, bool isQuarantine)
        {
            Name = name;
            LastName = lastName;
            Password = password;
            IsQuarantine = isQuarantine;
        }

        // For creating account
        public UserModel(string name, string password, HashSaltModel hash)
        {
            Name = name;
            Password = password;
            HashSalt = hash;
        }
    }
}
