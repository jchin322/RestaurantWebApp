using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManager.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderID { get; set; }

        [Display(Name = "Item")]
        public string FoodName { get; set; }


        public Decimal Price { get; set; }
    }
}
