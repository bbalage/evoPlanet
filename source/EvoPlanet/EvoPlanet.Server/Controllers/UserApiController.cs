using EvoPlanet.Server.Models;
using EvoPlanet.Server.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EvoPlanet.Server.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserApiService _userApiService;

        public UserController(IUserApiService userApiService)
        {
            _userApiService = userApiService ?? throw new ArgumentNullException(nameof(userApiService));
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userApiService.GetAllUsers();
            return Ok(users);
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("{userId}")]
        public IActionResult GetUserById(int userId)
        {
            try
            {
                var user = _userApiService.GetAllUsers().FirstOrDefault(u => u.UserId == userId);
                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return NotFound("User not found.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPost]
        public IActionResult AddUser(User newUser)
        {
            try
            {
                _userApiService.AddUser(newUser);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPut("{userId}")]
        public IActionResult UpdateUser(int userId, User updatedUser)
        {
            try
            {
                _userApiService.UpdateUser(userId, updatedUser);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound($"Error: {ex.Message}");
            }
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            try
            {
                _userApiService.DeleteUser(userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound($"Error: {ex.Message}");
            }
        }
    }
}
