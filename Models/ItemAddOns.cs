using System;

namespace FoodApi.Models
{
    public class ItemAddOns
    {
        public Guid ItemAddOnID { get; set; }
        public string AddOnName { get; set; }
        public double AddOnPrice { get; set; }
    }
}