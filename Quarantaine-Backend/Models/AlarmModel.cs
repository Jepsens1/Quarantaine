using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarantaine_Backend.Models
{
    public enum AlarmState
    {
        NONE,
        LOW,
        MEDIUM,
        HIGH
    }
    // This class is purely for scaleability only towards an alarm system
    public class AlarmModel
    {
        public UserModel User { get; private set; }
        public AlarmState State { get; set; }

        public AlarmModel(UserModel user)
        {
            User = user;
            State = user.LastAlarmState;
        }
    }
}
