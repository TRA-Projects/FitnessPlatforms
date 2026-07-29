using FitnessPlatform.DTOs;
using FitnessPlatform.Services;
using Microsoft.AspNetCore.Authorization;
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

        // Get all users
        // Only Admin can see all users
       
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
            {
                var users = await _userService.GetAllUsers();
                return Ok(users);
            }

     
        // Get user by Id
         [Authorize]
         [HttpGet("{id}")]
            public async Task<IActionResult> GetUserById(int id)
            {
                var user = await _userService.GetUserById(id);
            // في حال عدم وجود المستخدم في قاعدة البيانات
            if (user == null)
                    return NotFound("User not found.");// إرجاع كود 404

            return Ok(user);
            }

            
            // Register new user
            [HttpPost("register")]
            public async Task<IActionResult> Register(RegisterDTO dto)
            {
                var result = await _userService.Register(dto);
            // إذا فشل التسجيل (مثلاً البريد الإلكتروني مستخدم مسبقاً)
            if (!result)
                    return BadRequest("Email already exists.");// إرجاع كود 400

            return Ok("User registered successfully.");
            }

        
        // Login user and return JWT Token
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var result = await _userService.Login(dto);

            // إذا كانت بيانات الدخول خاطئة (البريد أو كلمة المرور)
            if (result == null)
                return Unauthorized("Invalid email or password.");//400


            return Ok(result);//200
        }




      
        // Update user
        [Authorize]
        [HttpPut("{id}")]
            public async Task<IActionResult> UpdateUser(int id, UpdateUserDTO dto)
            {
                var result = await _userService.UpdateUser(id, dto);

                if (!result)
                    return NotFound("User not found.");

                return Ok("User updated successfully.");
            }

     
        // Delete user
        [Authorize(Roles = "Admin")]
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

