using System;

namespace FoodApi.Models
{
    public class Vendors
    {
        public Guid VendorID { get; set; }
        public string VendorCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string VendorFName { get; set; }
        public string VendorLName { get; set; }
        public string VendorEmail { get; set; }
        public string VendorPhone1 { get; set; }
        public string VendorPhone2 { get; set; }
        public string VendorAddress { get; set; }
        public string LocationMAP { get; set; }
        public string DeliveryProvision { get; set; }
        public Guid CityID { get; set; }
        public Guid RegionID { get; set; }
        public string Active { get; set; }
    }
}