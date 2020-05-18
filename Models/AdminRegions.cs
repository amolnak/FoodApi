using System;
using System.ComponentModel.DataAnnotations;

namespace FoodApi.Models
{
    public class AdminRegions
    {
        [Key]
        public Guid AdminRegionID { get; set; }
        public Guid AdminID { get; set; }
        public Guid RegionID { get; set; }
    }
}