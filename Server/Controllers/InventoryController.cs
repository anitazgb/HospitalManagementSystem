using HMS.Models;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories;

namespace Server.Controllers
{
    //API Controller for managing inventory
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryRepository _repository;

        public InventoryController()
        {
            _repository = new InventoryRepository(new DB.ManagmentSystemDbContext());
        }

        // Endpoint for getting all inventory items
        [HttpGet]
        public async Task<IEnumerable<InventoryItem>> Get() 
            => await _repository.GetAll();

        // Endpoint for adding an inventory item
        [HttpPost]
        public async Task<IActionResult> Add(string name, int quantity)
        {
            var item = new InventoryItem { Name = name, Quantity = quantity };
            await _repository.Insert(item);
            return Ok("Item added successfully.");
        }

        // Endpoint for deleting an inventory item
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = new InventoryItem { ID = id };
            await _repository.Delete(item);
            return Ok("Item deleted successfully.");
        }

        // Endpoint for updating an inventory item
        [HttpPost("Update")]
        public async Task<IActionResult> Update(int id,int quantity)
        {
            var item = new InventoryItem { ID = id, Quantity = quantity };
            await _repository.Update(item);
            return Ok("Item updated successfully.");
        }
    }
}
