using Microsoft.EntityFrameworkCore;
using The_Grocery_Manager.Models;
using The_Grocery_Manager.Service;

namespace The_Grocery_Manager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register the DbContext with SQL Server
            builder.Services.AddDbContext<GroceryDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register InventoryService as Scoped
            builder.Services.AddScoped<InventoryService>();

            builder.Services.AddHttpContextAccessor();



            builder.Services.AddSession(); // Add this before builder.Build()


            var app = builder.Build();

            app.UseSession();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthorization();

            // Default route points to the Login page
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=User}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
