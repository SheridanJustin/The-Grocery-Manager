namespace The_Grocery_Manager.Models
{
    public class UserDashboardViewModel
    {
        public List<Recipe> Recipes { get; set; }
        public List<Inventory> Inventory { get; set; }
        public List<ShoppingList> ShoppingList { get; set; }
    }
}
