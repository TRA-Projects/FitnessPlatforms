using FitnessPlatform.DTOs;
using FitnessPlatform.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPlatform.Controllers
{

    [Route("api/[controller]")] // show the path of API => api/Exercise
    [ApiController]
    [Authorize] 
    public class ExerciseController : ControllerBase
    {
        private readonly ExerciseService _exerciseService;

        public ExerciseController(ExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        //==========================
        // GET: api/Exercise
        // Admin + Member + Trainer
        [HttpGet]
        [Authorize(Roles = "Admin,Member,Trainer")]
        public async Task<IActionResult> GetAllExercises()
        {
            var exercises = await _exerciseService.GetAllExercises();

            return Ok(exercises);
        }

        //==========================
        // GET: api/Exercise/{id}
        // Admin + Member + Trainer
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Member,Trainer")]
        public async Task<IActionResult> GetExerciseById(int id)
        {
            var exercise = await _exerciseService.GetExerciseById(id);

            if (exercise == null)
                return NotFound("Exercise not found.");

            return Ok(exercise);
        }

        //==========================
        // POST: api/Exercise
        // Admin + Trainer
        [HttpPost]
        [Authorize(Roles = "Admin,Trainer")]
        public async Task<IActionResult> CreateExercise(ExerciseInputDTO dto)
        {
            await _exerciseService.CreateExercise(dto);

            return Ok("Exercise created successfully.");
        }

        //==========================
        // PUT: api/Exercise/{id}
        // Admin + Trainer 
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Trainer")]
        public async Task<IActionResult> UpdateExercise(int id,ExerciseInputDTO dto)
        {
            var result = await _exerciseService.UpdateExercise(id, dto);

            if (!result)
                return NotFound("Exercise not found.");

            return Ok("Exercise updated successfully.");
        }

        //==========================
        // DELETE: api/Exercise/{id}
        // Admin + Trainer
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Trainer")]
        public async Task<IActionResult> DeleteExercise(int id)
        {
            var result = await _exerciseService.DeleteExercise(id);

            if (!result)
                return NotFound("Exercise not found.");

            return Ok("Exercise deleted successfully.");
        }

    }
}
