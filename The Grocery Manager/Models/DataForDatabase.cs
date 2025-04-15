using Microsoft.EntityFrameworkCore;

namespace The_Grocery_Manager.Models
{
    public class DataForDatabase
    {
        public static void LoadData(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider
                .GetRequiredService<GroceryDbContext>();
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if (!context.Recipes.Any())
                {
                    context.Recipes.AddRange(
                        new Recipe { RecipeId = 1, Name = "Spaghetti Bolognese", Instructions = "Boil pasta, cook meat with sauce.", UserId = 1 },
                        new Recipe { RecipeId = 2, Name = "Chicken Stir Fry", Instructions = "Stir-fry chicken and vegetables with soy sauce.", UserId = 2 },
                        new Recipe { RecipeId = 3, Name = "Pancakes", Instructions = "Mix batter and cook on griddle.", UserId = 1 },
                        new Recipe { RecipeId = 4, Name = "Grilled Cheese", Instructions = "Butter bread and grill with cheese in between.", UserId = 3 },
                        new Recipe { RecipeId = 5, Name = "Salad Bowl", Instructions = "Chop vegetables and toss with dressing.", UserId = 2 }


                        );
                    context.SaveChanges();
                }
                if (!context.Ingredients.Any())
                {
                    context.Ingredients.AddRange(
                    new Ingredient { IngredientId = 1, Name = "Spaghetti", Unit = "Box", Description = "Dry pasta noodles" },
                    new Ingredient { IngredientId = 2, Name = "Ground Beef", Unit = "Pound", Description = "Lean ground beef" },
                    new Ingredient { IngredientId = 3, Name = "Chicken", Unit = "Piece", Description = "Boneless chicken breast" },
                    new Ingredient { IngredientId = 4, Name = "Flour", Unit = "Cup", Description = "All-purpose flour for pancakes" },
                    new Ingredient { IngredientId = 5, Name = "Cheddar Cheese", Unit = "Slice", Description = "Sliced cheddar cheese"}
                    );
                    context.SaveChanges();

                }
                if (!context.Inventories.Any())
                {
                    context.Inventories.AddRange(
                    new Inventory { InventoryId = 1, UserId = 1, ItemName = "Spaghetti", Quantity = 2, Unit = "Boxes", LastUpdated = new DateTime(2025, 04, 11) },
                    new Inventory { InventoryId = 2, UserId = 1, ItemName = "Ground Beef", Quantity = 1, Unit = "Pound", LastUpdated = new DateTime(2025, 04, 11) },
                    new Inventory { InventoryId = 3, UserId = 2, ItemName = "Chicken Breast", Quantity = 4, Unit = "Pieces", LastUpdated = new DateTime(2025, 04, 11) },
                    new Inventory { InventoryId = 4, UserId = 3, ItemName = "Cheese", Quantity = 1, Unit = "Block", LastUpdated = new DateTime(2025, 04, 11) },
                    new Inventory { InventoryId = 5, UserId = 2, ItemName = "Lettuce", Quantity = 1, Unit = "Head", LastUpdated = new DateTime(2025, 04, 11) }

                    );
                    context.SaveChanges();

                }
            }
        }


    }
}
