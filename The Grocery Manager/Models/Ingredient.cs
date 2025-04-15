namespace The_Grocery_Manager.Models
{
    /// <summary>
    /// Represents an individual ingredient required for recipes and shopping lists.
    /// </summary>
    public class Ingredient
    {
        public int IngredientId { get; set; }

        /// <summary>
        /// The name of the ingredient (e.g., "Tomato", "Salt").
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The unit of measurement for the ingredient (e.g., grams, pieces, ml).
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// A general description or notes about the ingredient.
        /// </summary>
        public string Description { get; set; }

        // Navigation property for linking with ShoppingList
        public ICollection<ShoppingList> ShoppingLists { get; set; }
    }
}
