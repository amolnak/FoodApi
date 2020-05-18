using System;
using System.ComponentModel.DataAnnotations;

namespace FoodApi.Models
{
    public class City
    {
        [Key]
        public Guid CityID { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public string Active { get; set; }
    }
}