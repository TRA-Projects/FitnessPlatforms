using FitnessPlatform.DTOs;
using FitnessPlatform.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly ExerciseService _exerciseService;

        public ExerciseController(ExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        //==========================
        // GET: api/Exercise
        [HttpGet]
        public async Task<IActionResult> GetAllExercises()
        {
            var exercises = await _exerciseService.GetAllExercises();

            return Ok(exercises);
        }

        //==========================
        // GET: api/Exercise/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExerciseById(int id)
        {
            var exercise = await _exerciseService.GetExerciseById(id);

            if (exercise == null)
                return NotFound("Exercise not found.");

            return Ok(exercise);
        }

        //==========================
        // POST: api/Exercise
        [HttpPost]
        public async Task<IActionResult> CreateExercise(ExerciseInputDTO dto)
        {
            await _exerciseService.CreateExercise(dto);

            return Ok("Exercise created successfully.");
        }

        //==========================
        // PUT: api/Exercise/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExercise(int id,ExerciseInputDTO dto)
        {
            var result = await _exerciseService.UpdateExercise(id, dto);

            if (!result)
                return NotFound("Exercise not found.");

            return Ok("Exercise updated successfully.");
        }

        //==========================
        // DELETE: api/Exercise/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercise(int id)
        {
            var result = await _exerciseService.DeleteExercise(id);

            if (!result)
                return NotFound("Exercise not found.");

            return Ok("Exercise deleted successfully.");
        }

    }
}
