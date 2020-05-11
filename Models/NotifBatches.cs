using System;

namespace FoodApi.Models
{
    public class NotifBatches
    {
        public int NotifBatchId { get; set; }
        public DateTime? DateCreated { get; set; }
        public string NotifBatchStatus { get; set; }
    }
}