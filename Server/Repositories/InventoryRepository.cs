using HMS.Models;
using Microsoft.EntityFrameworkCore;
using Server.DB;

namespace Server.Repositories
{
    // Repository for managing inventory items
    public class InventoryRepository(ManagmentSystemDbContext dbContext)
    {
        // Method for getting all inventory items
        public async Task<List<InventoryItem>> GetAll() 
            => await dbContext.InventoryItems.ToListAsync();

        // Method for getting an inventory item by ID
        public async Task<InventoryItem> GetById(int id)
            => await dbContext.InventoryItems.Where(i=>i.ID == id).FirstOrDefaultAsync();

        // Method for inserting an inventory item
        public async Task Insert(InventoryItem item)
        {
            await dbContext.InventoryItems.AddAsync(item);
            await dbContext.SaveChangesAsync();
        }

        // Method for deleting an inventory item
        public async Task Delete(InventoryItem item)
        {
            await dbContext.InventoryItems.Where(p => p.ID == item.ID).ExecuteDeleteAsync();
            await dbContext.SaveChangesAsync();
        }

        // Method for updating an inventory item
        public async Task Update(InventoryItem item)
        {
            await dbContext.InventoryItems.Where(p => p.ID == item.ID).ExecuteUpdateAsync(x => x.SetProperty(r => r.Quantity, item.Quantity));
            await dbContext.SaveChangesAsync();
        }
    }
}
