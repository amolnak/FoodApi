using System;

namespace FoodApi.Models
{
    public class Region
    {
        public Guid RegionID { get; set; }
        public string RegionName { get; set; }
        public string Pincode { get; set; }
        public Guid CityID { get; set; }
        public string Active { get; set; }
    }
}