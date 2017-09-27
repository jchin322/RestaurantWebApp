using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManager.Data;
using RestaurantManager.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManager.Controllers
{
    public class MenuItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenuItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        private readonly string query = "SELECT * FROM MenuItem ORDER BY MenuLocation, FoodType";
        private readonly string specQuey = "SELECT * FROM MenuItem WHERE MenuLocation = {0} ORDER BY FoodType";
        private string filterQuery;

        // GET: MenuItems
        public async Task<IActionResult> Index(RestaurantMenu? restaurant, string searchString)
        {
            // A search string was entered, filter on this.
            if (!String.IsNullOrEmpty(searchString) && restaurant == null)
            {
                // Translate the search string to menu item.
                // Strip all spaces to account for malformed user input.
                switch (searchString.ToLower().Replace(" ", "").Trim())
                {
                    case "lapizza":
                        filterQuery = "SELECT * FROM MenuItem WHERE MenuLocation = 0 ORDER BY MenuLocation, FoodType";
                        break;
                    case "lepouletfrise":
                        filterQuery = "SELECT * FROM MenuItem WHERE MenuLocation = 1 ORDER BY MenuLocation, FoodType";
                        break;
                    case "denrosaelefanten":
                        filterQuery = "SELECT * FROM MenuItem WHERE MenuLocation = 2 ORDER BY MenuLocation, FoodType";
                        break;
                    default:
                        // Null searchString to indicate bad input.
                        searchString = null;
                        break;
                }
                // Retrieve all filtered menu items and info
                // then order them on restaurant and food type.
                if (!String.IsNullOrEmpty(searchString))
                {
                    var filteredMenuItems = await _context.MenuItems
                        .FromSql(filterQuery)
                        .AsNoTracking()
                        .ToListAsync();
                    return View(filteredMenuItems);
                }
                // Update current filter string;
                //ViewData["CurrentFilter"] = searchString;
                ViewData["FilterCheck"] = "true";
                var defaultMenuItems = await _context.MenuItems
                    .FromSql(query)
                    .AsNoTracking()
                    .ToListAsync();
                return View(defaultMenuItems);
            }
            // First time seeing all menu items with no filter value
            // return all items.
            else if (String.IsNullOrEmpty(searchString) && restaurant == null)
            {
                var defaultMenuItems = await _context.MenuItems
                    .FromSql(query)
                    .AsNoTracking()
                    .ToListAsync();
                return View(defaultMenuItems);
            }
            else // we have clicked on the gallery Menu link for a specific restaurant
            {
                ViewData["Appetizer"] = "Appetizers";
                ViewData["Entree"] = "Entrees";
                ViewData["Dessert"] = "Desserts";
                ViewData["Drink"] = "Drinks";
                switch (restaurant) // Check the restaurant id from the URL
                {
                    case RestaurantMenu.LP:
                        ViewData["RestaurantName"] = "La Pizza";
                        break;
                    case RestaurantMenu.LPF:
                        ViewData["RestaurantName"] = "Le Poulet Frise";
                        break;
                    case RestaurantMenu.DRE:
                        ViewData["RestaurantName"] = "Den Rosa Elefanten";
                        break;
                }
                // Return to the view only the menu items that are related
                // to the selected restaurant and order them
                // by restaurant and food type.
                var specSortedMenuItems = await _context.MenuItems
                    .FromSql(specQuey, restaurant)
                    .AsNoTracking()
                    .ToListAsync();
                return View(specSortedMenuItems);
            }
        }

        // GET: MenuItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItem = await _context.MenuItems
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.MenuItemID == id);
            if (menuItem == null)
            {
                return NotFound();
            }

            return View(menuItem);
        }

        // GET: MenuItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MenuItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuLocation,FoodName,FoodType,FoodPrice")] MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menuItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menuItem);
        }

        // GET: MenuItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItem = await _context.MenuItems.SingleOrDefaultAsync(m => m.MenuItemID == id);
            if (menuItem == null)
            {
                return NotFound();
            }
            return View(menuItem);
        }

        // POST: MenuItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenuLocation,FoodName,FoodType,FoodPrice")] MenuItem menuItem)
        {
            if (id != menuItem.MenuItemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuItemExists(menuItem.MenuItemID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(menuItem);
        }

        // GET: MenuItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItem = await _context.MenuItems
                .SingleOrDefaultAsync(m => m.MenuItemID == id);
            if (menuItem == null)
            {
                return NotFound();
            }

            return View(menuItem);
        }

        // POST: MenuItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuItem = await _context.MenuItems.SingleOrDefaultAsync(m => m.MenuItemID == id);
            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuItemExists(int id)
        {
            return _context.MenuItems.Any(e => e.MenuItemID == id);
        }
    }
}
