using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using The_Grocery_Manager.Models;

namespace The_Grocery_Manager.Controllers
{
    public class ShoppingListController : Controller
    {
        private IRecipeRepository _recipeRepository;
        private GroceryDbContext _groceryDbContext;

        public ShoppingListController(IRecipeRepository recipeRepository, GroceryDbContext groceryDbContext)
        {
            _groceryDbContext = groceryDbContext;
            _recipeRepository = recipeRepository;
        }

        [HttpPost]
        public IActionResult Add(int ingredientId)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "User");

                var ingredient = _groceryDbContext.Ingredients.FirstOrDefault(i => i.IngredientId == ingredientId);
                if (ingredient == null)
                    return NotFound();

                var shoppingItem = new ShoppingList
                {
                    Title = ingredient.Name,
                    UserId = userId.Value,
                    GeneratedOn = DateTime.Now
                };
                _groceryDbContext.ShoppingLists.Add(shoppingItem);
                _groceryDbContext.SaveChanges();

                return RedirectToAction("MyRecipes", "Recipe");
            
            }
        public IActionResult Index()
        {
            return View();
        }
    }
}
