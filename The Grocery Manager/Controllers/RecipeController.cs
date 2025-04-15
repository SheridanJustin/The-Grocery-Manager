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
            int? userId = HttpContext.Session.GetInt32("UserId");
            if(userId == null)
            {
                Console.WriteLine("User ID not found in session.");
                return RedirectToAction("Login", "Account");
            }

            

            var userRecipes = _recipeRepository.GetRecipesByUser(userId.Value);
            if (!userRecipes.Any())
            {
                Console.WriteLine("No recipes for " + userId);
            }
                var model = new RecipesViewModel
                {
                    RecipesList = userRecipes.ToList()
                };

                return View("Recipes", model);
        }

       


        public IActionResult Index()
        {
            return RedirectToAction("MyRecipes");
        }
    }
}
