using System;
using System.ComponentModel.DataAnnotations;

namespace FoodApi.Models
{
    public class ItemAddOns
    {
        [Key]
        public Guid ItemAddOnID { get; set; }
        public string AddOnName { get; set; }
        public double AddOnPrice { get; set; }
    }
}