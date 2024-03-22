using Plugin.LocalNotification;
using Quarantaine_APP.Interfaces;

namespace Quarantaine_APP.Services
{
    public class NotificationService : INotifyService
    {
        static int Id = 1;
        public async Task ShowNotification()
        {
            if (await LocalNotificationCenter.Current.AreNotificationsEnabled() == false)
            {
                await LocalNotificationCenter.Current.RequestNotificationPermission();
            }
            var notification = new NotificationRequest
            {
                NotificationId = Id,
                Title = "Test",
                Description = "Test Description"
            };
            if (await LocalNotificationCenter.Current.Show(notification))
                Id++;
        }
    }
}
