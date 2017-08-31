using System;
using System.ComponentModel.DataAnnotations;


namespace RestaurantManager.Models
{
    public class Employee
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        [Required]
        public bool ManagerStatus { get; set; }

        // Decimal formatting goes here.
        [DataType(DataType.Currency)]
        [Display(Name = "Current Wage")]
        public Decimal Wage { get; set; }

        // Restaurant where an employee works
        [Display(Name = "Working Restaurant")]
        public string CurrentWorkingRestaurant { get; set; }
    }
}
