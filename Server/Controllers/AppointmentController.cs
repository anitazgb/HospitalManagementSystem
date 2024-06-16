using HMS.Models;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories;

namespace Server.Controllers
{
    // API controller for managing appointments
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentRepository _appointmentRepository;
        public AppointmentController()
        {
            _appointmentRepository = new AppointmentRepository(new DB.ManagmentSystemDbContext());
        }

        // Endpoint for adding a new appointment
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] string patientID, [FromForm] string doctorID, [FromForm] string datetime)
        {
            var newAppointment = new AppointmentEntity() { DoctorID = new Guid(doctorID), PatientID = new Guid(patientID), Date = DateTime.Parse(datetime) };
            await _appointmentRepository.Insert(newAppointment);
            return Ok("Appointment added successfully.");
        }

        // Endpoint for deleting an appointment
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromForm] string appointmentID)
        {
            var appointmentForDelete = new AppointmentEntity() { ID = int.Parse(appointmentID) };
            await _appointmentRepository.Delete(appointmentForDelete);
            return Ok("Appointment deleted successfully.");
        }

        // Endpoint for getting all appointments
        [HttpGet("GetAppointments")]
        public async Task<IActionResult> GetAppointments()
        {
            var appointments = await _appointmentRepository.GetAll();
            return Ok(appointments);
        }
    }
}
