using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManager.Models
{
    public enum FoodType
    {
        Appetizer, Entree, Dessert, Drink
    }

    // LP = La Pizza
    // LPF = Le Poulet Frise
    // DRE = Den Rosa Elefanten
    public enum RestaurantMenu
    {
        LP, LPF, DRE
    }

    public class MenuItem
    {
        public int MenuItemID { get; set; }

        [Display(Name = "Location")]
        public RestaurantMenu MenuLocation { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string FoodName { get; set; }

        [Display(Name = "Type")]
        public FoodType FoodType { get; set; }

        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public Decimal FoodPrice { get; set; }
    }
}