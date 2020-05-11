using System;

namespace FoodApi.Models
{
    public class Notifications
    {
        public Guid NotificationId { get; set; }
        public DateTime? NotifCreatedDate { get; set; }
        public string NotifTitle { get; set; }
        public string NotificationType { get; set; }
        public DateTime? ScheduleUTCTime { get; set; }
        public string ShortMess { get; set; }
        public string LongMess { get; set; }
        public string NotificationStatus { get; set; }
        public Guid UserSubscriptionID { get; set; }
    }
}