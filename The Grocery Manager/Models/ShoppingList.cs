namespace The_Grocery_Manager.Models
{
    /// <summary>
    /// Represents a shopping list, including ingredients that the user needs to buy.
    /// </summary>
    public class ShoppingList
    {
        public int ShoppingListId { get; set; }

        public int UserId { get; set; }

        /// <summary>
        /// Title for the shopping list (e.g., "Weekly Groceries").
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Date when the list was generated.
        /// </summary>
        public DateTime GeneratedOn { get; set; }

        // Navigation properties
        public User User { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
       // public ICollection<ShoppingListIngredient> ShoppingListIngredients { get; set; } = new List<ShoppingListIngredient>();


    }
}
