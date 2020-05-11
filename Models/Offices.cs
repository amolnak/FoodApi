using System;

namespace FoodApi.Models
{
    public class Offices
    {
        public Guid OfficeID { get; set; }
        public string OfficeName { get; set; }
        public string Address { get; set; }
        public string LocationMAP { get; set; }
        public string EmailID { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public Guid CityID { get; set; }
        public Guid RegionID { get; set; }
        public int? NoofSubscribers { get; set; }
        public string Active { get; set; }
    }
}