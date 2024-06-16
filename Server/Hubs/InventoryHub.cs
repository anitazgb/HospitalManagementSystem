using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Server.Hubs
{
    [Authorize]
    public class InventoryHub : Hub
    {
        // Method for updating inventory levels
        public async Task UpdateInventory()
        {
            await Clients.All.SendAsync("UpdateInventory");
        }
    }
}
