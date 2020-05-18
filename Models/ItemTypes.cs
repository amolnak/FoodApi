using System;
using System.ComponentModel.DataAnnotations;

namespace FoodApi.Models
{
    public class ItemTypes
    {
        [Key]
        public Guid ItemTypeID { get; set; }
        public string ItemType { get; set; }
    }
}