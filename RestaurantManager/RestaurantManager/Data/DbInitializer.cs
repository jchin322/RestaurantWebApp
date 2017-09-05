using RestaurantManager.Models;
using System;
using System.Linq;

namespace RestaurantManager.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any employees
            if (context.Employees.Any())
            {
                return;
            }

            var employees = new Employee[]
            {
                new Employee{EmployeeID = 1, LastName = "Chin", FirstMidName = "Matthew", HireDate = DateTime.Parse("2017-12-25"),
                    ManagerStatus = true, Wage = 29.99M, CurrentWorkingRestaurant = "La Pizza"},
                new Employee{EmployeeID = 2, LastName = "Bob", FirstMidName = "Bobert", HireDate = DateTime.Parse("2000-1-20"),
                    ManagerStatus = false, Wage = 12.99M, CurrentWorkingRestaurant = "La Pizza"},
                new Employee{EmployeeID = 3, LastName = "Roberts", FirstMidName = "Lauren", HireDate = DateTime.Parse("1999-4-14"),
                    ManagerStatus = true, Wage = 15.99M, CurrentWorkingRestaurant = "Le Poulet Frise"},
                new Employee{EmployeeID = 4, LastName = "Dunkin", FirstMidName = "Bread", HireDate = DateTime.Parse("2015-2-18"),
                    ManagerStatus = false, Wage = 9.99M, CurrentWorkingRestaurant = "Le Poulet Frise"},
                new Employee{EmployeeID = 5, LastName = "Studio", FirstMidName = "Benet", HireDate = DateTime.Parse("2007-9-14"),
                    ManagerStatus = true, Wage = 20.99M, CurrentWorkingRestaurant = "Den Rosa Elefanten"},
                new Employee{EmployeeID = 6, LastName = "Bratwursten", FirstMidName = "Waffle", HireDate = DateTime.Parse("2008-10-25"),
                    ManagerStatus = false, Wage = 9.99M, CurrentWorkingRestaurant = "Den Rosa Elefanten"}
            };
            foreach (Employee e in employees)
            {
                context.Employees.Add(e);
            }
            context.SaveChanges();

            var menus = new MenuItem[]
            {
                new MenuItem{MenuItemID = RestaurantMenu.LP, FoodName = "Carrot Crudite", FoodType = FoodType.Appetizer, FoodPrice = 12M},
                new MenuItem{MenuItemID = RestaurantMenu.LP, FoodName = "Olive Tapanade", FoodType = FoodType.Appetizer, FoodPrice = 9M},
                new MenuItem{MenuItemID = RestaurantMenu.LPF, FoodName = "Pork Loin en Croute", FoodType = FoodType.Appetizer, FoodPrice = 5M},
                new MenuItem{MenuItemID = RestaurantMenu.LPF, FoodName = "Mussels a la Plancha", FoodType = FoodType.Entree, FoodPrice = 9M},
                new MenuItem{MenuItemID = RestaurantMenu.LPF, FoodName = "Zucchini Spritz", FoodType = FoodType.Drink, FoodPrice = 18M},
                new MenuItem{MenuItemID = RestaurantMenu.DRE, FoodName = "Eggplant Rollitoli", FoodType = FoodType.Appetizer, FoodPrice = 9M},
                new MenuItem{MenuItemID = RestaurantMenu.DRE, FoodName = "Veal Lasagna", FoodType = FoodType.Entree, FoodPrice = 18M },
                new MenuItem{MenuItemID = RestaurantMenu.DRE, FoodName = "Chocolate Cake", FoodType = FoodType.Dessert, FoodPrice = 9M },
                new MenuItem{MenuItemID = RestaurantMenu.DRE, FoodName = "DooFroo Fritzer", FoodType = FoodType.Drink, FoodPrice = 8M },

            };
            foreach (MenuItem m in menus)
            {
                context.Menus.Add(m);
            }
            context.SaveChanges();

            var restaurants = new Restaurant[]
            {
                new Restaurant{RestaurantID = 1, RestaurantName = "La Pizza", BuildingNumber = 123, StreetName = "Pizza Street",
                    City = "St. Louis", State = StateType.MO, ZipCode = 63105, ManagerLastName = "Chin", ManagerFirstMidName = "Matthew",
                    QuaterlySales = 0M, YearlySales = 0M },
                new Restaurant{RestaurantID = 2, RestaurantName = "La Poulet Frise", BuildingNumber = 234, StreetName = "Roable Avenue",
                    City = "New York City", State = StateType.NY, ZipCode = 10001, ManagerLastName = "", ManagerFirstMidName = "",
                    QuaterlySales = 0M, YearlySales = 0M },
                new Restaurant{RestaurantID = 3, RestaurantName = "Den Rosa Elefanten", BuildingNumber = 456, StreetName = "Puler Street",
                    City = "Allentown", State = StateType.PA, ZipCode = 18101, ManagerLastName = "", ManagerFirstMidName = "",
                    QuaterlySales = 0M, YearlySales = 0M }
            };
            foreach (Restaurant r in restaurants)
            {
                context.Restaurants.Add(r);
            }
            context.SaveChanges();
        }
    }
}
