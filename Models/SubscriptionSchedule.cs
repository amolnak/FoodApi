using System;
using System.ComponentModel.DataAnnotations;

namespace FoodApi.Models
{
    public class SubscriptionSchedule
    {
        [Key]
        public Guid SubSchID { get; set; }
        public string ScheduleType { get; set; }
        public string ScheduleName { get; set; }
    }
}