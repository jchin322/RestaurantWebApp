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
        public RestaurantMenu MenuItemID { get; set; }

        public string FoodName { get; set; }

        public FoodType FoodType { get; set; }

        [DataType(DataType.Currency)]
        public Decimal FoodPrice { get; set; }
    }
}