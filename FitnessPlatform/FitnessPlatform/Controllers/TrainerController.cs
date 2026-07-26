using FitnessPlatform.DTOs;
using FitnessPlatform.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly TrainerService _trainerService;

        public TrainerController(TrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        // Get all trainers
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trainers = await _trainerService.GetAllTrainers();
            return Ok(trainers);
        }


        // Create trainer
        [HttpPost]
        public async Task<IActionResult> Create(TrainerInputDTOs dto)
        {
            await _trainerService.CreateTrainer(dto);

            return Ok("Trainer created successfully.");
        }

        // Update trainer
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TrainerInputDTOs dto)
        {
            var result = await _trainerService.UpdateTrainer(id, dto);

            if (!result)
                return NotFound();

            return Ok("Trainer updated successfully.");
        }

        // Delete trainer
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