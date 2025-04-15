namespace The_Grocery_Manager.Models
{
    /// <summary>
    /// Author: Sannan Ali
    /// Inventory.cs - Model class for tracking user inventory items at home.
    /// To manage stock levels, update quantity, and prevent duplicate purchases.
    /// </summary>
    public class Inventory
    {
        public int InventoryId { get; set; }

        /// <summary>
        /// Foreign key reference to User
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Name of the ingredient or item
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Quantity available at home
        /// </summary>
        public double Quantity { get; set; }

        /// <summary>
        /// Unit of measurement (e.g., grams, ml, pieces)
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Timestamp of last update
        /// </summary>
        public DateTime LastUpdated { get; set; }

        // Navigation Property
        public User User { get; set; }
    }
}
