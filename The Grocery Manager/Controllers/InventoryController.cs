using Microsoft.AspNetCore.Mvc;
using The_Grocery_Manager.Models;

namespace The_Grocery_Manager.Controllers
{
    public class InventoryController : Controller
    {
        private readonly GroceryDbContext _context;

        public InventoryController(GroceryDbContext context)
        {
            _context = context;
        }

        // GET: /Inventory
        public IActionResult Index()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "User");

            var inventory = _context.Inventories
                                    .Where(i => i.UserId == userId)
                                    .OrderBy(i => i.ItemName)
                                    .ToList();

            return View(inventory);
        }
    }
}
