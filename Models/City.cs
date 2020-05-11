using System;

namespace FoodApi.Models
{
    public class City
    {
        public Guid CityID { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public string Active { get; set; }
    }
}