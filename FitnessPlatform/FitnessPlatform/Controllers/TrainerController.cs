using FitnessPlatform.DTOs;
using FitnessPlatform.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FitnessPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Authentication: يجب تسجيل الدخول للوصول للـ Controller
    public class TrainerController : ControllerBase
    {
        private readonly TrainerService _trainerService;

        public TrainerController(TrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        // Get all trainers
        // Any authenticated user can view trainers
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trainers = await _trainerService.GetAllTrainers();
            return Ok(trainers);
        }


        // Create trainer
        // Only Admin can create trainer
        [HttpPost]
        public async Task<IActionResult> Create(TrainerInputDTOs dto)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            await _trainerService.CreateTrainer(dto, userId);

            return Ok("Trainer created successfully.");
        }

        // Update trainer
        // Only Admin can update trainer
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TrainerInputDTOs dto)
        {
            var result = await _trainerService.UpdateTrainer(id, dto);

            if (!result)
                return NotFound();

            return Ok("Trainer updated successfully.");
        }

        // Delete trainer
        // Only Admin can delete trainer
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _trainerService.DeleteTrainer(id);

            if (!result)
                return NotFound();

            return Ok("Trainer deleted successfully.");
        }
    }
}