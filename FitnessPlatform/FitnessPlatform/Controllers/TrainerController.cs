using FitnessPlatform.DTOs;
using FitnessPlatform.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // يجب تسجيل الدخول للوصول إلى هذا الـ Controller
    public class TrainerController : ControllerBase
    {
        private readonly TrainerService _trainerService;

        public TrainerController(TrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        // GET: api/Trainer
        // Admin, Trainer, and Member can view trainers
        [Authorize(Roles = "Admin,Trainer,Member")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trainers = await _trainerService.GetAllTrainers();
            return Ok(trainers);
        }

        // POST: api/Trainer
        // Only Admin can create a trainer
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(TrainerInputDTOs dto)
        {
            await _trainerService.CreateTrainer(dto);
            return Ok("Trainer created successfully.");
        }

        // PUT: api/Trainer/5
        // Only Admin can update a trainer
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TrainerInputDTOs dto)
        {
            var result = await _trainerService.UpdateTrainer(id, dto);

            if (!result)
                return NotFound("Trainer not found.");

            return Ok("Trainer updated successfully.");
        }

        // DELETE: api/Trainer/5
        // Only Admin can delete a trainer
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _trainerService.DeleteTrainer(id);

            if (!result)
                return NotFound("Trainer not found.");

            return Ok("Trainer deleted successfully.");
        }
    }
}