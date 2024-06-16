using HMS.Models;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories;

namespace Server.Controllers
{
    // API Controller for handling chat messages
    [Route("api/chats")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ChatRepository _chatRepository;
        public ChatController()
        {
            _chatRepository = new ChatRepository(new DB.ManagmentSystemDbContext());
        }

        // Endpoint for adding a chat message
        [HttpPost]
        public async Task<IActionResult> Add(string patientID, string content)
        {
            var newChat = new ChatEntity() { PatientID = new Guid(patientID), Content = content, Date = DateTime.Now };
            await _chatRepository.Insert(newChat);
            return Ok("Chat added successfully.");
        }

        // Endpoint for retrieving all chat messages
        [HttpGet("GetChats")]
        public async Task<IActionResult> Get()
        {
            var chats = await _chatRepository.GetAll();
            return Ok(chats);
        }
    }
}
