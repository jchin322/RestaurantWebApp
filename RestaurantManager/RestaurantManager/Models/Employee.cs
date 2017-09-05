using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManager.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

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
