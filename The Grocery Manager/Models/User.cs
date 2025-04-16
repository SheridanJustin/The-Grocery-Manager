namespace The_Grocery_Manager.Models
{
    /// <summary>
    /// Represents a registered user in the system.
    /// Justin Kadyrov
    /// </summary>
    public class User
    {
        public int UserId { get; set; }

        /// <summary>
        /// User's display or full name.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// User's email for login and communication.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Securely hashed password.
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Date of registration.
        /// </summary>
        public DateTime RegisteredOn { get; set; }

        // Initialize collections to avoid null ModelState errors

        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

        public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
        public ICollection<ShoppingList> ShoppingLists { get; set; } = new List<ShoppingList>();
    }
}
