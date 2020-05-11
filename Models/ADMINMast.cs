using System;

namespace FoodApi.Models
{
    public class ADMINMast
    {
        public Guid AdminID { get; set; }
        public string Name { get; set; }
        public string EmailID { get; set; }
        public string UserName { get; set; }
        public Guid? CityID { get; set; }
        public string Password { get; set; }
        public byte? Accesslevel { get; set; }
        public string Active { get; set; }
    }
}