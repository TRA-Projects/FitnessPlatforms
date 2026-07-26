using FitnessPlatform.DTOs;
using FitnessPlatform.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPlatform.Controllers
{

        [ApiController]
        [Route("api/[controller]")]
        public class WorkoutSessionController : ControllerBase
        {
            private readonly WorkoutSessionService _workoutSessionService;

            public WorkoutSessionController(WorkoutSessionService workoutSessionService)
            {
                _workoutSessionService = workoutSessionService;
            }


            //====================================================
            // GET: api/WorkoutSession
            // Get all workout sessions
            //====================================================
            [HttpGet]
            public async Task<IActionResult> GetAllWorkoutSessions()
            {
                var sessions = await _workoutSessionService.GetAllWorkoutSessions();

                return Ok(sessions);
            }


            //====================================================
            // GET: api/WorkoutSession/{id}
            // Get workout session by id
            //====================================================
            [HttpGet("{id}")]
            public async Task<IActionResult> GetWorkoutSessionById(int id)
            {
                var session = await _workoutSessionService.GetWorkoutSessionById(id);

                if (session == null)
                    return NotFound("Workout session not found.");

                return Ok(session);
            }


            //====================================================
            // POST: api/WorkoutSession
            // Create new workout session
            //====================================================
            [HttpPost]
            public async Task<IActionResult> CreateWorkoutSession(
                [FromBody] WorkoutSessionInputDTO dto)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _workoutSessionService.CreateWorkoutSession(dto);

                return Ok("Workout session created successfully.");
            }


            //====================================================
            // PUT: api/WorkoutSession/{id}
            // Update workout session
            //====================================================
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateWorkoutSession(
                int id,
                [FromBody] WorkoutSessionInputDTO dto)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _workoutSessionService
                    .UpdateWorkoutSession(id, dto);

                if (!result)
                    return NotFound("Workout session not found.");

                return Ok("Workout session updated successfully.");
            }


            //====================================================
            // DELETE: api/WorkoutSession/{id}
            // Delete workout session
            //====================================================
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteWorkoutSession(int id)
            {
                var result = await _workoutSessionService
                    .DeleteWorkoutSession(id);

                if (!result)
                    return NotFound("Workout session not found.");

                return Ok("Workout session deleted successfully.");
            }
        }
    }

