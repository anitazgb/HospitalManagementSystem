using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Security.Claims;

namespace Server.Hubs
{
    [Authorize]
    public class MyHub : Hub
    {
        // Storing users' ConnectionIds
        private static ConcurrentDictionary<string, string> userConnections = new ConcurrentDictionary<string, string>();
        public async Task SendMessage(string message)
        {
            var userId = Context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var role = Context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (role == "admin")
            {
                // Administrator can see all messages
                await Clients.All.SendAsync("ReceiveMessage", userId, message);
            }
            else
            {
                // Client can see only their own messages and the administrator's messages
                await Clients.Caller.SendAsync("ReceiveMessage", userId, message);
                var adminClients = Clients.Group("admin");
                await adminClients.SendAsync("ReceiveMessage", userId, message);
            }
        }
        // Method for sending a message to a specific user
        public async Task SendMessageToUser(string targetUsername, string message)
        {
            var userId = Context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var role = Context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            // Only an administrator user can do this
            if (role == "admin")
            {
                if (userConnections.TryGetValue(targetUsername, out var connectionId))
                {
                    await Clients.Client(connectionId).SendAsync("ReceiveMessage", userId, message);
                }
                else
                {
                    await Clients.Caller.SendAsync("ReceiveMessage", "System", "User not connected.");
                }
            }
        }

        // When connecting to this hub, each user ID is added to userConnections.
        // This is needed so that later we can get their connectionId by ID and
        // send a message to this specific connectionId (specific user)
        public override async Task OnConnectedAsync()
        {
            var userId = Context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            userConnections[userId] = Context.ConnectionId;

            var role = Context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (role == "admin")
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "admin");
            }
            await base.OnConnectedAsync();
            
        }
        // Upon disconnection, additionally remove the user from userConnections.
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var userId = Context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            userConnections.TryRemove(userId, out _);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
