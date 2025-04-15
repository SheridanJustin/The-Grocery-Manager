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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
            new User { UserId = 2, FullName = "Alice Smith",Email = "alice@example.com",PasswordHash = "hashed_password_1",RegisteredOn = new DateTime(2024, 01, 10) },
            new User { UserId = 3, FullName = "Bob Johnson",Email = "bob@example.com",PasswordHash = "hashed_password_2",RegisteredOn = new DateTime(2024, 02, 15) },
            new User { UserId = 4,FullName = "Charlie Brown", Email = "charlie@example.com", PasswordHash = "hashed_password_3", RegisteredOn = new DateTime(2024, 03, 05) }
            );

            modelBuilder.Entity<Recipe>().HasData(
                 new Recipe { RecipeId = 1, Name = "Spaghetti Bolognese", Instructions = "Boil pasta, cook meat with sauce.", UserId = 1 },
                 new Recipe { RecipeId = 2, Name = "Chicken Stir Fry", Instructions = "Stir-fry chicken and vegetables with soy sauce.", UserId = 2 },
                 new Recipe { RecipeId = 3, Name = "Pancakes", Instructions = "Mix batter and cook on griddle.", UserId = 1 },
                 new Recipe { RecipeId = 4, Name = "Grilled Cheese", Instructions = "Butter bread and grill with cheese in between.", UserId = 3 },
                 new Recipe { RecipeId = 5, Name = "Salad Bowl", Instructions = "Chop vegetables and toss with dressing.", UserId = 2 }

                );

            modelBuilder.Entity<Ingredient>().HasData(
                 new Ingredient { IngredientId = 1, Name = "Spaghetti", Unit = "Box", Description = "Dry pasta noodles", RecipeId = 1 },
                 new Ingredient { IngredientId = 2, Name = "Ground Beef", Unit = "Pound", Description = "Lean ground beef", RecipeId = 1 },
                 new Ingredient { IngredientId = 3, Name = "Chicken", Unit = "Piece", Description = "Boneless chicken breast", RecipeId = 2 },
                 new Ingredient { IngredientId = 4, Name = "Flour", Unit = "Cup", Description = "All-purpose flour for pancakes", RecipeId = 3 },
                 new Ingredient { IngredientId = 5, Name = "Cheddar Cheese", Unit = "Slice", Description = "Sliced cheddar cheese", RecipeId = 4 }
                );
            modelBuilder.Entity<Inventory>().HasData(
                 new Inventory { InventoryId = 1, UserId = 1, ItemName = "Spaghetti", Quantity = 2, Unit = "Boxes", LastUpdated = new DateTime(2025, 04, 11) },
                 new Inventory { InventoryId = 2, UserId = 1, ItemName = "Ground Beef", Quantity = 1, Unit = "Pound", LastUpdated = new DateTime(2025, 04, 11) },
                 new Inventory { InventoryId = 3, UserId = 2, ItemName = "Chicken Breast", Quantity = 4, Unit = "Pieces", LastUpdated = new DateTime(2025, 04, 11) },
                 new Inventory { InventoryId = 4, UserId = 3, ItemName = "Cheese", Quantity = 1, Unit = "Block", LastUpdated = new DateTime(2025, 04, 11) },
                 new Inventory { InventoryId = 5, UserId = 2, ItemName = "Lettuce", Quantity = 1, Unit = "Head", LastUpdated = new DateTime(2025, 04, 11) });


              


        }
    }
}
