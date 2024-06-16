using HMS.Models;
using Microsoft.EntityFrameworkCore;
using Server.DB;

namespace Server.Repositories
{
    // Repository for the Reception entity
    public class ReceptionRepository(ManagmentSystemDbContext dbContext)
    {
        // Method for getting all receptions
        public async Task<List<ReceptionEntity>> GetAll()
            => await dbContext.Receptions.ToListAsync();

        // Method for inserting a new reception
        public async Task Insert(ReceptionEntity reception)
        {
            await dbContext.Receptions.AddAsync(reception);
            await dbContext.SaveChangesAsync();
        }
    }
}
