using System;
using System.ComponentModel.DataAnnotations;

namespace FoodApi.Models
{
    public class VendorItems
    {
        [Key]
        public Guid vendorItemID { get; set; }
        public Guid VendorId { get; set; }
        public Guid ItemID { get; set; }
        public int? Capacity { get; set; }
        public double? PerPlateRate { get; set; }
        public int? PreferentialRating { get; set; }
    }
}