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
                // Redirect to home or dashboard
                return RedirectToAction("Dashboard", "Home");
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



    }
}
