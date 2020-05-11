using System;

namespace FoodApi.Models
{
    public class NotifAppInst
    {
        public long NotifAppInstId { get; set; }
        public Guid NotificationId { get; set; }
        public Guid AppInstId { get; set; }
        public int NotifBatchId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateSent { get; set; }
        public byte? FailCount { get; set; }
        public string AppInstNotifStatus { get; set; }
    }
}