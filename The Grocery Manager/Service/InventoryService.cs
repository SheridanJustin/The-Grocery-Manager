using The_Grocery_Manager.Models;

namespace The_Grocery_Manager.Service
{
    /// <summary>
    /// Author: Sannan Ali
    /// InventoryService.cs - Service class for managing inventory-related 
    /// logic and database operations.
    /// </summary>
    public class InventoryService
    {
        private readonly GroceryDbContext _context;

        public InventoryService(GroceryDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all inventory items for a specific user.
        /// </summary>
        public List<Inventory> GetInventoryByUser(int userId)
        {
            return _context.Inventories
                           .Where(i => i.UserId == userId)
                           .ToList();
        }

        /// <summary>
        /// Adds a new inventory item or updates existing if it exists.
        /// </summary>
        public void AddOrUpdateInventoryItem(Inventory item)
        {
            // Check if the user already has this item in their inventory
            var existing = _context.Inventories
                                   .FirstOrDefault(i => i.UserId == item.UserId && i.ItemName == item.ItemName);
            if (existing != null)
            {
                existing.Quantity = item.Quantity;
                existing.LastUpdated = DateTime.Now;
                _context.Inventories.Update(existing);
            }
            else
            {
                item.LastUpdated = DateTime.Now;
                _context.Inventories.Add(item);
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// Removes an inventory item by its ID.
        /// </summary>
        public void RemoveInventoryItem(int id)
        {
            var item = _context.Inventories.Find(id);
            if (item != null)
            {
                _context.Inventories.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
