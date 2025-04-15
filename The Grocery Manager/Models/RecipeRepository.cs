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
        public IQueryable<Recipe> GetRecipesByUser(int userId)
        {
            return _context.Recipes.Include(r => r.Ingredients).Where(r => r.UserId == userId);
        }


        public IQueryable<Recipe> GetDinnerRecipes(string category)
        {
            // Add filtering logic as needed
            return _context.Recipes.Where(r => r.Name.Contains(category));
        }
    }

}
