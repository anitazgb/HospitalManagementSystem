using HMS.Models;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories;

namespace Server.Controllers
{
    // API controller for handling sicknesses
    [Route("api/sickness")]
    [ApiController]
    public class SicknessController : ControllerBase
    {
        private readonly SicknessRepository _sicknessRepository;
        public SicknessController()
        {
            _sicknessRepository = new SicknessRepository(new DB.ManagmentSystemDbContext());
        }

        // Endpoint for adding a new sickness
        [HttpPost]
        public async Task<IActionResult> AddSickness([FromForm] string title)
        {
            var newSickness = new SicknessEntity() { Title = title };
            await _sicknessRepository.Insert(newSickness);
            return Ok("Sickness added successfully.");
        }

        // Endpoint for retrieving all sicknesses
        [HttpGet("GetSickness")]
        public async Task<IActionResult> GetSickness()
        {
            var sickness = await _sicknessRepository.GetAll();
            return Ok(sickness);
        }
    }
}
