using System;

namespace FoodApi.Models
{
    public class Users
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Address { get; set; }
        public string LocationMAP { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int? Age { get; set; }
        public DateTime? DateRegistered { get; set; }
        public Guid CityID { get; set; }
        public Guid RegionID { get; set; }
        public string Active { get; set; }
    }
}