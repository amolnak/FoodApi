using System;

namespace FoodApi.Models
{
    public class DeliveryBoys
    {
        public Guid DeliveryBoyID { get; set; }
        public string DBFName { get; set; }
        public string DBLName { get; set; }
        public string DBUserName { get; set; }
        public string DBPassword { get; set; }
        public string DBAddress { get; set; }
        public string DBEmail { get; set; }
        public string DBPhone1 { get; set; }
        public string DBPhone2 { get; set; }
        public Guid DBCityID { get; set; }
        public Guid DBRegionID { get; set; }
        public string LicenseNo { get; set; }
        public Guid? VehicleID { get; set; }
    }
}