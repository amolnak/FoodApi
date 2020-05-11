using System;

namespace FoodApi.Models
{
    public class DeliveryVehicles
    {
        public Guid VehicleID { get; set; }
        public string VehicleNo { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string ChasisNo { get; set; }
        public string FuelType { get; set; }
        public string GPSEnabled { get; set; }
    }
}