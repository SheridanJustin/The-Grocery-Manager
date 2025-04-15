using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace The_Grocery_Manager.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "Description", "Name", "RecipeId", "Unit" },
                values: new object[,]
                {
                    { 1, "Dry pasta noodles", "Spaghetti", null, "Box" },
                    { 2, "Lean ground beef", "Ground Beef", null, "Pound" },
                    { 3, "Boneless chicken breast", "Chicken", null, "Piece" },
                    { 4, "All-purpose flour for pancakes", "Flour", null, "Cup" },
                    { 5, "Sliced cheddar cheese", "Cheddar Cheese", null, "Slice" }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "InventoryId", "ItemName", "LastUpdated", "Quantity", "Unit", "UserId" },
                values: new object[,]
                {
                    { 1, "Spaghetti", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.0, "Boxes", 1 },
                    { 2, "Ground Beef", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, "Pound", 1 }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "RecipeId", "Instructions", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "Boil pasta, cook meat with sauce.", "Spaghetti Bolognese", 1 },
                    { 3, "Mix batter and cook on griddle.", "Pancakes", 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FullName", "PasswordHash", "RegisteredOn" },
                values: new object[,]
                {
                    { 2, "alice@example.com", "Alice Smith", "hashed_password_1", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "bob@example.com", "Bob Johnson", "hashed_password_2", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "charlie@example.com", "Charlie Brown", "hashed_password_3", new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "InventoryId", "ItemName", "LastUpdated", "Quantity", "Unit", "UserId" },
                values: new object[,]
                {
                    { 3, "Chicken Breast", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.0, "Pieces", 2 },
                    { 4, "Cheese", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, "Block", 3 },
                    { 5, "Lettuce", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, "Head", 2 }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "RecipeId", "Instructions", "Name", "UserId" },
                values: new object[,]
                {
                    { 2, "Stir-fry chicken and vegetables with soy sauce.", "Chicken Stir Fry", 2 },
                    { 4, "Butter bread and grill with cheese in between.", "Grilled Cheese", 3 },
                    { 5, "Chop vegetables and toss with dressing.", "Salad Bowl", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "InventoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "InventoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "InventoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "InventoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "InventoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);
        }
    }
}
