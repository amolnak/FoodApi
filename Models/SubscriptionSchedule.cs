using System;

namespace FoodApi.Models
{
    public class SubscriptionSchedule
    {
        public Guid SubSchID { get; set; }
        public string ScheduleType { get; set; }
        public string ScheduleName { get; set; }
    }
}