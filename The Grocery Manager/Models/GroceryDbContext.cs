using Microsoft.EntityFrameworkCore;


namespace The_Grocery_Manager.Models
{
    public class GroceryDbContext : DbContext
    {
        public GroceryDbContext(DbContextOptions<GroceryDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
    }



}
