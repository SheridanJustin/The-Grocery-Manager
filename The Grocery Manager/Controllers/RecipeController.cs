using Microsoft.AspNetCore.Mvc;
using The_Grocery_Manager.Models;
using The_Grocery_Manager.Models.View_Models;

namespace The_Grocery_Manager.Controllers
{
    //Jeffrey Pincombe
    public class RecipeController : Controller
    {
        private IRecipeRepository _recipeRepository;
        private GroceryDbContext _groceryDbContext;

        public RecipeController(IRecipeRepository recipeRepository, GroceryDbContext groceryDbContext)
        {
            _groceryDbContext = groceryDbContext;
            _recipeRepository = recipeRepository;
        }
        [HttpGet]
        public IActionResult MyRecipes()
        {
            var userIdStr = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdStr) || !int.TryParse(userIdStr, out int userId))
            {
                Console.WriteLine("User ID not found in session.");
                return RedirectToAction("Login", "Account");
            }
            var userRecipes = _recipeRepository.GetAllRecipes();
            if (!userRecipes.Any())
            {
                Console.WriteLine("No recipes to show");
            }
                var model = new RecipesViewModel
                {
                    RecipesList = userRecipes.ToList()
                };

                return View(model);
        }


        public IActionResult Index()
        {
            return View("Recipes");
        }
    }
}
