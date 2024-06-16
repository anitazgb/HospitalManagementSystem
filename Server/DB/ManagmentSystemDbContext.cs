using HMS.Models;
using Microsoft.EntityFrameworkCore;

namespace Server.DB
{
    public class ManagmentSystemDbContext : DbContext
    {
        // Defining database entities
        public DbSet<InventoryItem> InventoryItems => Set<InventoryItem>();
        public DbSet<SicknessEntity> Sickness => Set<SicknessEntity>();
        public DbSet<ReceptionEntity> Receptions => Set<ReceptionEntity>();
        public DbSet<AppointmentEntity> Appointments => Set<AppointmentEntity>();
        public DbSet<IssueEntity> Issues => Set<IssueEntity>();
        public DbSet<ChatEntity> Chats => Set<ChatEntity>();
        public DbSet<ReportString> Reports => Set<ReportString>();
        public ManagmentSystemDbContext()
        {
            // Do not track changes in the database, handle everything through queries
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
           // Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=THINKSTATIONP3\\SQLEXPRESS;Initial Catalog=HMS;Integrated Security=true;Encrypt=False;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReportString>().HasNoKey();
        }
    }
}
