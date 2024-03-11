using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarantaine_Backend.Models
{
    public class HashSaltModel
    {
        public string Hash { get; set; }
        public string Salt { get; set; }

        public HashSaltModel(string hash, string salt)
        {
            Hash = hash;
            Salt = salt;
        }
    }
}
