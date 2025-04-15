using Microsoft.AspNetCore.Mvc;
using The_Grocery_Manager.Models;

namespace The_Grocery_Manager.Controllers
{
    public class UserController : Controller
    {
        private readonly GroceryDbContext _context;

        public UserController(GroceryDbContext context)
        {
            _context = context;
        }

        // GET: /User/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /User/Login
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.PasswordHash == password);

            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.UserId); // ✅ Save user ID in session
                return RedirectToAction("Dashboard", "User");
            }

            ViewBag.ErrorMessage = "Invalid email or password.";
            return View();
        }


        // GET: /User/Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User newUser, string ConfirmPassword)
        {
            if (newUser.PasswordHash != ConfirmPassword)
            {
                ViewBag.ErrorMessage = "Passwords do not match.";
                return View(newUser);
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                ViewBag.ErrorMessage = "Model errors: " + string.Join("; ", errors);
                return View(newUser);
            }

            newUser.RegisteredOn = DateTime.Now;
            _context.Users.Add(newUser);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }




        // GET: User/Dashboard
        public IActionResult Dashboard()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            // Get user's recipes, inventory, and shopping list
            var recipes = _context.Recipes.Where(r => r.UserId == userId).ToList();
            var inventory = _context.Inventories.Where(i => i.UserId == userId).ToList();
            var shoppingList = _context.ShoppingLists.Where(s => s.UserId == userId).ToList();

            // Pass data to the view
            var model = new UserDashboardViewModel
            {
                Recipes = recipes,
                Inventory = inventory,
                ShoppingList = shoppingList
            };

            return View(model);
        }



    }
}
