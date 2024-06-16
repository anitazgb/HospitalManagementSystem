using HMS.Models;
using Microsoft.EntityFrameworkCore;
using Server.DB;

namespace Server.Repositories
{
    // This class is responsible for handling all database operations related to chat messages
    public class ChatRepository(ManagmentSystemDbContext dbContext)
    {
        // This method retrieves ALL chat messages from the database
        public async Task<List<ChatEntity>> GetAll()
            => await dbContext.Chats.ToListAsync(); // convert to a List
        
        // insert a new chat message TO the database
        public async Task Insert(ChatEntity chat) 
        {
            await dbContext.Chats.AddAsync(chat);
            await dbContext.SaveChangesAsync();
        }
    }
}
