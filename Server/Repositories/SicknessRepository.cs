using HMS.Models;
using Microsoft.EntityFrameworkCore;
using Server.DB;

namespace Server.Repositories
{
    // Repository for handling sickness data
    public class SicknessRepository(ManagmentSystemDbContext dbContext)
    {
        // Get all sicknesses
        public async Task<List<SicknessEntity>> GetAll()
            => await dbContext.Sickness.ToListAsync(); 

        // Insert a new sickness
        public async Task Insert(SicknessEntity sickness)
        {
            await dbContext.Sickness.AddAsync(sickness);
            await dbContext.SaveChangesAsync();
        }
    }
}
