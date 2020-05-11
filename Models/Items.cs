using System;

namespace FoodApi.Models
{
    public class Items
    {
        public Guid ItemID { get; set; }
        public Guid ItemTypeID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemImage { get; set; }
        public double ItemPrice { get; set; }
        public string VegNonVeg { get; set; }
        public Guid ItemAddOnID { get; set; }
        public string StarReceipe { get; set; }
    }
}