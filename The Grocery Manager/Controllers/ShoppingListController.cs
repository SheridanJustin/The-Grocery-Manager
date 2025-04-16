using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using The_Grocery_Manager.Models;
using System.Linq;
using System.Threading.Tasks;

public class ShoppingListController : Controller
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly GroceryDbContext _groceryDbContext;

    public ShoppingListController(IRecipeRepository recipeRepository, GroceryDbContext groceryDbContext)
    {
        _recipeRepository = recipeRepository;
        _groceryDbContext = groceryDbContext;
    }

    // Display the current user's shopping list
    public async Task<IActionResult> Index()
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null)
            return RedirectToAction("Login", "User");

        var shoppingList = await _groceryDbContext.ShoppingLists
            .Include(s => s.Ingredients)
            .FirstOrDefaultAsync(s => s.UserId == userId);

        return View(shoppingList);
    }

    [HttpPost]
    public async Task<IActionResult> Remove(int shoppingListId, int ingredientId)
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null)
            return RedirectToAction("Login", "User");

        if (shoppingListId <= 0 || ingredientId <= 0)
        {
            TempData["Error"] = "Invalid input.";
            return RedirectToAction("Index");
        }

        var shoppingList = await _groceryDbContext.ShoppingLists
            .Include(s => s.Ingredients)
            .FirstOrDefaultAsync(s => s.ShoppingListId == shoppingListId && s.UserId == userId);

        if (shoppingList == null)
        {
            TempData["Error"] = "Shopping list not found or you do not have access.";
            return RedirectToAction("Index");
        }

        var ingredientToRemove = shoppingList.Ingredients
            .FirstOrDefault(i => i.IngredientId == ingredientId);

        if (ingredientToRemove == null)
        {
            TempData["Error"] = "Ingredient not found in the shopping list.";
            return RedirectToAction("Index");
        }

        shoppingList.Ingredients.Remove(ingredientToRemove);
        await _groceryDbContext.SaveChangesAsync();
        TempData["Success"] = "Ingredient removed successfully.";
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Add(int ingredientId)
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null)
            return RedirectToAction("Login", "User");

        if (ingredientId <= 0)
        {
            TempData["Error"] = "Invalid ingredient ID.";
            return RedirectToAction("Index");
        }

        var ingredient = await _groceryDbContext.Ingredients
            .FirstOrDefaultAsync(i => i.IngredientId == ingredientId);
        if (ingredient == null)
        {
            TempData["Error"] = "Ingredient not found.";
            return RedirectToAction("Index");
        }

        var shoppingList = await _groceryDbContext.ShoppingLists
            .Include(s => s.Ingredients)
            .FirstOrDefaultAsync(s => s.UserId == userId);

        if (shoppingList == null)
        {
            shoppingList = new ShoppingList
            {
                UserId = userId.Value,
                GeneratedOn = DateTime.Now,
                Title = "My Shopping List", // Set a default title
                Ingredients = new List<Ingredient>()
            };
            _groceryDbContext.ShoppingLists.Add(shoppingList);
        }

        if (!shoppingList.Ingredients.Any(i => i.IngredientId == ingredientId))
        {
            shoppingList.Ingredients.Add(ingredient);
            TempData["Success"] = $"{ingredient.Name} added to shopping list.";
        }
        else
        {
            TempData["Info"] = $"{ingredient.Name} is already in the shopping list.";
        }

        await _groceryDbContext.SaveChangesAsync();
        return RedirectToAction("Index");
    }


    [HttpPost]
    public async Task<IActionResult> RemoveAll(int shoppingListId)
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null)
            return RedirectToAction("Login", "User");

        if (shoppingListId <= 0)
        {
            TempData["Error"] = "Invalid shopping list ID.";
            return RedirectToAction("Index");
        }

        var shoppingList = await _groceryDbContext.ShoppingLists
            .Include(s => s.Ingredients)
            .FirstOrDefaultAsync(s => s.ShoppingListId == shoppingListId && s.UserId == userId);

        if (shoppingList == null)
        {
            TempData["Error"] = "Shopping list not found or you do not have access.";
            return RedirectToAction("Index");
        }

        if (shoppingList.Ingredients.Any())
        {
            shoppingList.Ingredients.Clear();
            await _groceryDbContext.SaveChangesAsync();
            TempData["Success"] = "All ingredients removed from the shopping list.";
        }
        else
        {
            TempData["Info"] = "The shopping list is already empty.";
        }

        return RedirectToAction("Index");
    }

}