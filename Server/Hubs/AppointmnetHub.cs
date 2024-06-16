using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Server.Hubs
{
    [Authorize]
    public class AppointmnetHub : Hub
    {
        // Method for updating appoitments
        public async Task UpdateAppointments()
        {
            await Clients.All.SendAsync("UpdateAppointments");
        }
    }
}
