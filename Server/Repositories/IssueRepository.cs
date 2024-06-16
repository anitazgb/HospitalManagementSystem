using HMS.Models;
using Microsoft.EntityFrameworkCore;
using Server.DB;

namespace Server.Repositories
{
    // Repository for managing issues in the database
    public class IssueRepository(ManagmentSystemDbContext dbContext)
    {
        // Get all issues from the database
        public async Task<List<IssueEntity>> GetAll()
            => await dbContext.Issues.ToListAsync();

        //  Insert a new issue into the database
        public async Task Insert(IssueEntity issue)
        {
            await dbContext.Issues.AddAsync(issue);
            await dbContext.SaveChangesAsync();
        }
    }
}
