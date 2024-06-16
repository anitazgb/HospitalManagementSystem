using Microsoft.AspNetCore.Mvc;
using Server.Repositories;

namespace Server.Controllers
{
    // API controller for reports
    [Route("api/reports")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportRepository _reportRepository;
        public ReportController()
        {
            _reportRepository = new ReportRepository(new DB.ManagmentSystemDbContext());
        }

        // Endpoints for generating Reception reports
        [HttpGet("Reception")]
        public async Task<IActionResult> Reception(string start, string end)
        {
            var report = await _reportRepository.Reception(start, end);
            return Ok(report);
        }

        // Endpoints for generating Sickness reports
        [HttpGet("Sickness")]
        public async Task<IActionResult> Sickness(string start, string end)
        {
            var report = await _reportRepository.Sickness(start, end);
            return Ok(report);
        }

        // Endpoints for generating Issue reports
        [HttpGet("Issue")]
        public async Task<IActionResult> Issues(string start, string end)
        {
            var report = await _reportRepository.Issue(start, end);
            return Ok(report);
        }
    }
}
