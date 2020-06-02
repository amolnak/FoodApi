using System;
using System.ComponentModel.DataAnnotations;

namespace FoodApi.Models
{
    public class UserSubscriptions
    {
        [Key]
        public Guid UserSubscriptionID { get; set; }
        public Guid userId { get; set; }
        public Guid ItemID { get; set; }
        public int? Quantity { get; set; }
        public int? ItemAddOnQty { get; set; }
        public Guid SubSchID { get; set; }
        public double? DiscountApplied { get; set; }
        public Guid OfferID { get; set; }
        public double? SubscriptionPrice { get; set; }
        public Guid FamMembID { get; set; }
        public DateTime? SubscriptionStartDate { get; set; }
        public DateTime? SubscriptionEndDate { get; set; }
        public string ScheduledDates { get; set; }
        public DateTime? ScheduledTime { get; set; }
    }
}