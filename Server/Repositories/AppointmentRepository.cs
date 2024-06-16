using HMS.Models;
using Microsoft.EntityFrameworkCore;
using Server.DB;

namespace Server.Repositories
{
    //  Repository for working with the AppointmentEntity table
    public class AppointmentRepository(ManagmentSystemDbContext dbContext)
    {
        public async Task<List<AppointmentEntity>> GetAll() // get all objects from AppointmentEntity
            => await dbContext.Appointments.ToListAsync();  // convert to list
        public async Task Insert(AppointmentEntity appointment) // add new object to AppointmentEntity
        {
            await dbContext.Appointments.AddAsync(appointment);
            await dbContext.SaveChangesAsync(); // save changes
        }
        public async Task Delete(AppointmentEntity appointment) // delete object from AppointmentEntity
        {
            await dbContext.Appointments.Where(p => p.ID == appointment.ID).ExecuteDeleteAsync();
            await dbContext.SaveChangesAsync();  // save changes
        }
    }
}
