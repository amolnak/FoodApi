using System;

namespace FoodApi.Models
{
    public class AdminRegions
    {
        public Guid AdminRegionID { get; set; }
        public Guid AdminID { get; set; }
        public Guid RegionID { get; set; }
    }
}