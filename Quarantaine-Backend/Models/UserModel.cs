using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarantaine_Backend.Models
{
    public struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    public struct Area
    {
        public Position Pos { get; set; }
        public int W { get; set; }
        public int H { get; set; }

    }
    public class UserModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public bool IsQuarantine { get; set; }
        public List<Area> IsolationArea { get; set; }
        public Position CurrentPosition { get; set; }

        public UserModel(int id, string name, string lastName, bool isQuarantine)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            IsQuarantine = isQuarantine;
        }
    }
}
