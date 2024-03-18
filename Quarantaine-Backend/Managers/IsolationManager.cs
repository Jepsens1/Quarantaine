using Quarantaine_Backend.Interfaces;
using Quarantaine_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarantaine_Backend.Managers
{
	// Starts a thread on initialization that checks if a user has left the isolation area
    public class IsolationManager
    {
		public List<AlarmModel> Alarms { get; private set; }

		private List<UserModel> users;
		private IDatabase<UserModel> db;
        public IsolationManager(IDatabase<UserModel> database)
        {
            users = new List<UserModel>();
			Alarms = new List<AlarmModel>();
			db = database;
			Thread t = new Thread(TriggerUserHasLeftIsolationArea);
			t.Start();
        }

        public void AddUserToIsolation(UserModel user)
		{
			db.Create(user);
			users.Add(user);
		}

		public void RemoveUserFromIsolation(UserModel user)
		{
			if (users.Contains(user))
			{
				db.Delete(user);
				users.Remove(user);
			}
		}

		public void SolveAlarm(UserModel user)
		{
			for (int i = 0; i < Alarms.Count; i++)
			{
				AlarmModel alarm = Alarms[i];
				if (alarm.User == user)
				{
					alarm.User.AlarmIsOn = false;
					db.Update(alarm.User);
					Alarms.RemoveAt(i);
					return;
				}
			}
		}

		private void TriggerUserHasLeftIsolationArea()
		{
			while (true)
			{
				for (int i = 0; i < users.Count; i++)
				{
					UserModel user = users[i];
					// Check if users coordinates is outside the isolation area coordinates
					if (user.CurrentPosition.X < user.IsolationArea.X || user.CurrentPosition.X > user.IsolationArea.W ||
                        user.CurrentPosition.Y < user.IsolationArea.Y || user.CurrentPosition.Y > user.IsolationArea.H)
					{
						// Increase the alarm state if user has left isolation before
						if (user.LastAlarmState != AlarmState.HIGH)
						{
							int lastAlarm = (int)user.LastAlarmState;
							lastAlarm++;
							user.LastAlarmState = (AlarmState)lastAlarm;
						}
						else
						{
							user.LastAlarmState = AlarmState.HIGH;
						}
						user.AlarmIsOn = true;
						db.Update(user);
						Alarms.Add(new AlarmModel(user));
					}
				}
			}
		}
	}
}
