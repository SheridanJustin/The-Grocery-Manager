namespace The_Grocery_Manager.Models
{
    /// <summary>
    /// Represents a recipe in the system.
    /// </summary>
    public class Recipe
    {
        public int RecipeId { get; set; }


        /// <summary>
        /// Foreign key to the owning user
        /// </summary>
        public int UserId { get; set; }


        /// <summary>
        /// The name of the recipe.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Instructions for preparing the recipe.
        /// </summary>
        public string Instructions { get; set; }

        // Navigation property for ingredients used in the recipe
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}
