using Microsoft.EntityFrameworkCore;

namespace The_Grocery_Manager.Models
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly GroceryDbContext _context;

        public RecipeRepository(GroceryDbContext context)
        {
            _context = context;
        }

        public IQueryable<Recipe> GetAllRecipes()
        {
            return _context.Recipes;
        }

        public IQueryable<Recipe> GetDinnerRecipes(string category)
        {
            // Add filtering logic as needed
            return _context.Recipes.Where(r => r.Name.Contains(category));
        }
    }

}
