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
    public class IsolationManager<T>
    {
		private UserModel user;
		private IDatabase<T> db;
		private Thread isolationThread;

		public IsolationManager(IDatabase<T> database)
        {
			db = database;
			user = UserModel.CurrentUser;
			isolationThread = new Thread(CheckUserHasLeftIsolationArea);
			isolationThread.Start();
        }

        public void AddToIsolation()
		{
			db.Create(user);
		}

		private void CheckUserHasLeftIsolationArea()
		{
			while (true)
			{
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
				}
				isolationThread.Sleep(500);
			}
		}
	}
}
