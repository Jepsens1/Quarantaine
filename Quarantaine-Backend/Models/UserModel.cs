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
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public bool IsQuarantine { get; set; }
        public Area IsolationArea { get; set; }
        public Position CurrentPosition { get; set; }
        public AlarmState LastAlarmState { get; set; }

        public UserModel(int id, string name, string lastName, bool isQuarantine)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            IsQuarantine = isQuarantine;
        }
    }
}
