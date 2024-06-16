using HMS.Models;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories;

namespace Server.Controllers
{
    // API controller for the reception (records of patients)
    [Route("api/reception")]
    [ApiController]
    public class ReceptionController : ControllerBase
    {
        private readonly ReceptionRepository _receptionRepository;
        public ReceptionController()
        {
            _receptionRepository = new ReceptionRepository(new DB.ManagmentSystemDbContext());
        }

        // Endpoint for adding a new reception record
        [HttpPost]
        public async Task<IActionResult> AddSickness([FromForm] string patientID, [FromForm] string doctorID, [FromForm] string sicknessID, [FromForm] string report)
        {
            var newReception = new ReceptionEntity() { DoctorID = new Guid(doctorID), PatientID = new Guid(patientID), SicknessID = int.Parse(sicknessID), Report = report, CreatedAt = DateTime.Now };
            await _receptionRepository.Insert(newReception);
            return Ok("Reception added successfully.");
        }

        // Endpoint for retrieving all reception records
        [HttpGet("GetReceptions")]
        public async Task<IActionResult> GetReceptions()
        {
            var receptions = await _receptionRepository.GetAll();
            return Ok(receptions);
        }
    }
}
