using Microsoft.AspNetCore.Mvc;
using The_Grocery_Manager.Models;

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

        public IActionResult MyRecipes()
        {

        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
