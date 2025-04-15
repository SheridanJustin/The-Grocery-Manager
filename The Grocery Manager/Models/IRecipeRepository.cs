namespace The_Grocery_Manager.Models
{
    //Jeffrey Pincombe
    public interface IRecipeRepository
    {
        IQueryable<Recipe> GetAllRecipes();

        IQueryable<Recipe> GetRecipesByUser(int userId);
        IQueryable<Recipe> GetDinnerRecipes ( string category);

    }
}
