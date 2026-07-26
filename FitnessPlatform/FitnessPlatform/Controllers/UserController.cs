using FitnessPlatform.DTOs;
using FitnessPlatform.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPlatform.Controllers
{

  
        [ApiController]
        [Route("api/[controller]")]
        public class UserController : ControllerBase
        {
            private readonly UserService _userService;

            // Constructor
            public UserController(UserService userService)
            {
                _userService = userService;
            }

            // GET: api/User
            // Get all users
            [HttpGet]
            public async Task<IActionResult> GetAllUsers()
            {
                var users = await _userService.GetAllUsers();
                return Ok(users);
            }

            // GET: api/User/5
            // Get user by Id
            [HttpGet("{id}")]
            public async Task<IActionResult> GetUserById(int id)
            {
                var user = await _userService.GetUserById(id);

                if (user == null)
                    return NotFound("User not found.");

                return Ok(user);
            }

            // POST: api/User/register
            // Register new user
            [HttpPost("register")]
            public async Task<IActionResult> Register(RegisterDTO dto)
            {
                var result = await _userService.Register(dto);

                if (!result)
                    return BadRequest("Email already exists.");

                return Ok("User registered successfully.");
            }

            // PUT: api/User/5
            // Update user
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateUser(int id, UpdateUserDTO dto)
            {
                var result = await _userService.UpdateUser(id, dto);

                if (!result)
                    return NotFound("User not found.");

                return Ok("User updated successfully.");
            }

            // DELETE: api/User/5
            // Delete user
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteUser(int id)
            {
                var result = await _userService.DeleteUser(id);

                if (!result)
                    return NotFound("User not found.");

                return Ok("User deleted successfully.");
            }
        }
    }

