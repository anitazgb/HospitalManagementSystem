using HMS.Models;
using Microsoft.EntityFrameworkCore;
using Server.DB;

namespace Server.Repositories
{
    // Repository for generating reports
    public class ReportRepository(ManagmentSystemDbContext dbContext)
    {
        // Method for generating a report on the number of receptions
        public async Task<List<ReportString>> Reception(string start, string end)
        {
            string sqlQuery = $"SELECT concat('Total Receptions: ' , COUNT(*)) AS TotalReceptions FROM [Receptions] where CreatedAt between '{start}' and '{end}' " +
                $"union all " +
                $"SELECT concat('By doctor: ',DoctorID, ' - ', COUNT(*)) AS TotalReceptions  " +
                $"FROM [Receptions] " +
                $"where CreatedAt between '{start}' and '{end}' " +
                $"GROUP BY DoctorID";
            return await dbContext.Reports.FromSqlRaw(sqlQuery).ToListAsync(); // Execute the query and return the result
        }

        // Method for generating a report on the number of receptions by sickness
        public async Task<List<ReportString>> Sickness(string start, string end)
        {
            string sqlQuery = $"SELECT Concat('Total receptions: ',COUNT(*)) AS Total FROM [Receptions] where [CreatedAt] between '{start}' and '{end}' " +
                $"UNION ALL " +
                $"select CONCAT('By sickness: ',B.Title,' - ',count(*)) AS Total " +
                $"from [Receptions] as A inner join [Sickness] as B on A.SicknessID=B.ID " +
                $"where [CreatedAt] between '{start}' and '{end}' " +
                $"group by B.Title";
            return await dbContext.Reports.FromSqlRaw(sqlQuery).ToListAsync(); // Execute the query and return the result
        }

        // Method for generating a report on the number of issues
        public async Task<List<ReportString>> Issue(string start, string end)
        {
            string sqlQuery = $"SELECT Concat('Total issues: ',COUNT(*)) AS Total FROM [Issues] where [DateTime] between '{start}' and '{end}' " +
                $"UNION ALL " +
                $"select CONCAT('Item: ',B.[Name],' - ',count(*)) AS Total  " +
                $"from [Issues] as A inner join [InventoryItems] as B on A.InventoryItemID=B.ID " +
                $"where [DateTime] between '{start}' and '{end}' " +
                $"group by B.[Name]";
            return await dbContext.Reports.FromSqlRaw(sqlQuery).ToListAsync(); // Execute the query and return the result
        }
    }
}
