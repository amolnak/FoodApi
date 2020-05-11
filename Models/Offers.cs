using System;

namespace FoodApi.Models
{
    public class Offers
    {
        public Guid OfferID { get; set; }
        public string OfferCode { get; set; }
        public string OfferName { get; set; }
        public string OfferDescription { get; set; }
        public string Offertype { get; set; }
        public Guid? ItemID { get; set; }
        public double? Price { get; set; }
        public string Active { get; set; }
    }
}