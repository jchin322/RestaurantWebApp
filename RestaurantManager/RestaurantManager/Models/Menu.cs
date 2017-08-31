using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManager.Models
{
    public enum FoodType
    {
        Appetizer, Entree, Dessert, Drink
    }

    public class Menu
    {
        public int MenuID { get; set; }

        public string FoodName { get; set; }

        public FoodType FoodType { get; set; }

        [DataType(DataType.Currency)]
        public Decimal FoodPrice { get; set; }
    }
}