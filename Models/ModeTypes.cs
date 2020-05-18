using System;
using System.ComponentModel.DataAnnotations;

namespace FoodApi.Models
{
    public class ModeTypes
    {
        [Key]
        public string ModeType { get; set; }
        public string ModeName { get; set; }
    }
}