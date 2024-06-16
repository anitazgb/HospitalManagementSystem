using HMS.Models;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories;

namespace Server.Controllers
{
    // API controller for managing issues
    [Route("api/issue")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IssueRepository _issueRepository;
        private readonly InventoryRepository _inventoryRepository;
        public IssueController()
        {
            var context = new DB.ManagmentSystemDbContext();
            _issueRepository = new IssueRepository(context);
            _inventoryRepository = new InventoryRepository(context);
        }

        // Endpoint for adding an issue
        [HttpPost]
        public async Task<IActionResult> Add(string patientID, string doctorID, int itemID, int quantity)
        {
            var newIssue = new IssueEntity() { DoctorID = new Guid(doctorID), PatientID = new Guid(patientID),InventoryItemID = itemID, DateTime = DateTime.Now, Quantity = quantity };
            var item = await _inventoryRepository.GetById(itemID);
            var isEmpty = item.Quantity - quantity <= 0;
            if (isEmpty)
                return BadRequest("Not available");

            item.Quantity -= quantity;
            await _issueRepository.Insert(newIssue);
            await _inventoryRepository.Update(item);
            return Ok("Issue added successfully.");
        }
    }
}
