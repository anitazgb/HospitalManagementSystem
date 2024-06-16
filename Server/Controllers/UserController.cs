using HMS.Models;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories;

namespace Server.Controllers
{
    // API controller for user management
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        public UserController()
        {
            _userRepository = new UserRepository();
        }

        // Endpoint for adding a user without a role
        [HttpPost]
        public async Task<IActionResult> AddUser([FromForm] string username, [FromForm] string password)
        {
            var newUser = new UserCollection() { Username = username, Password = password, Role = "patient" };
            await _userRepository.Insert(newUser);
            return Ok("User added successfully.");
        }

        // Endpoint for adding a user with a role
        [HttpPost("AddUserWithRole")]
        public async Task<IActionResult> AddUser(string username, string password, string role)
        {
            var newUser = new UserCollection() { Username = username, Password = password, Role = role };
            await _userRepository.Insert(newUser);
            return Ok("User added successfully.");
        }

        // Endpoint for deleting a user
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            await _userRepository.Delete(new Guid(id));
            return Ok("User deleted successfully.");
        }

        // Endpoint for updating a user
        [HttpPost("Update")]
        public async Task<IActionResult> Update(string id, string name,string password,string role)
        {
            if (role == "doctor" || role == "nurse" || role == "admin" || role == "patient")
            {
                var user = new UserCollection() { ID = new Guid(id), Password = password, Role = role, Username = name };
                await _userRepository.Update(user);
                return Ok("User updated successfully.");
            }
            else
                return BadRequest("Invalid user role");
            
        }

        // Endpoint for getting all patients
        [HttpGet("GetPatients")]
        public async Task<IActionResult> GetPatients([FromQuery] string role)
        {
            if (string.IsNullOrEmpty(role))
            {
                return BadRequest("Role is required.");
            }
            var patients = await _userRepository.GetBy(role);
            return Ok(patients);
        }

        // Endpoint for getting all users
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.Get();
            return Ok(users);
        }

        // Endpoint for getting a user by ID
        [HttpPost("GetName")]
        public async Task<IActionResult> GetName(string id)
        {
            var name = await _userRepository.GetName(id);
            return Ok(name);
        }
    }
}
