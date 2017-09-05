using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManager.Models
{

    public enum StateType
    {
        AL, AK, AZ, AR, CA, CO, CT, DE, FL, GA, HI, ID, IL,
        IN, IA, KS, KY, LA, ME, MD, MA, MI, MN, MS, MO, MT,
        NE, NV, NH, NJ, NM, NY, NC, ND, OH, OK, OR, PA, RI,
        SC, SD, TN, TX, UT, VT, VA, WA, WV, WI, WY
    }

    public class Restaurant
    {
        public int RestaurantID { get; set; }

        [Required]
        [Display(Name = "Restaurant Name")]
        public string RestaurantName { get; set; }

        [Required]
        [Display(Name = "Building Number")]
        public int BuildingNumber { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Street Name")]
        public string StreetName { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        public StateType State { get; set; }

        [Required(ErrorMessage = "ZIP is required.")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip")]
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public String ManagerLastName { get; set; }

        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public String ManagerFirstMidName { get; set; }

        [DataType(DataType.Currency)]
        public Decimal QuaterlySales { get; set; }

        [DataType(DataType.Currency)]
        public Decimal YearlySales { get; set; }
    }
}
