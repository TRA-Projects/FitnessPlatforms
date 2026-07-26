using FitnessPlatform.DTOs;
using FitnessPlatform.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutProgramController : ControllerBase
    {
        private readonly WorkoutProgramService _workoutProgramService;


        public WorkoutProgramController(
            WorkoutProgramService workoutProgramService)
        {
            _workoutProgramService = workoutProgramService;
        }


        // GET: api/WorkoutProgram
        [HttpGet]
        public async Task<IActionResult> GetAllWorkoutPrograms()
        {
            var programs = await _workoutProgramService.GetAllWorkoutPrograms();

            return Ok(programs);
        }


        // GET: api/WorkoutProgram/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkoutProgramById(int id)
        {
            var program = await _workoutProgramService.GetWorkoutProgramById(id);

            if (program == null)
                return NotFound();

            return Ok(program);
        }


        // POST: api/WorkoutProgram
        [Authorize(Roles = "Trainer")]
        [HttpPost]
        public async Task<IActionResult> CreateWorkoutProgram(
            WorkoutProgramInputDTO dto)
        {
            await _workoutProgramService.CreateWorkoutProgram(dto);

            return Ok("Workout Program created successfully");
        }


        // PUT: api/WorkoutProgram/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorkoutProgram(
            int id,
            WorkoutProgramInputDTO dto)
        {
            var result = await _workoutProgramService
                .UpdateWorkoutProgram(id, dto);


            if (!result)
                return NotFound();


            return Ok("Workout Program updated successfully");
        }


        // DELETE: api/WorkoutProgram/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkoutProgram(int id)
        {
            var result = await _workoutProgramService
                .DeleteWorkoutProgram(id);


            if (!result)
                return NotFound();


            return Ok("Workout Program deleted successfully");
        }
    }
}
