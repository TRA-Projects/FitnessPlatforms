using FitnessPlatform.DTOs;
using FitnessPlatform.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProgramExerciseController : ControllerBase
    {
        private readonly ProgramExerciseService _programExerciseService;


        public ProgramExerciseController(ProgramExerciseService programExerciseService)
        {
            _programExerciseService = programExerciseService;
        }

        //============================
        // GET: api/ProgramExercise
        // Member + Trainer
        [HttpGet]
        [Authorize(Roles = "Member,Trainer")]
        public async Task<IActionResult> GetAllProgramExercises()
        {
            var programExercises = await _programExerciseService.GetAllProgramExercises();

            return Ok(programExercises);
        }

        //============================
        // GET: api/ProgramExercise/{id}
        // Member + Trainer
        [HttpGet("{id}")]
        [Authorize(Roles = "Member,Trainer")]
        public async Task<IActionResult> GetProgramExerciseById(int id)
        {
            var programExercise = await _programExerciseService.GetProgramExerciseById(id);


            if (programExercise == null)

                return NotFound("Program Exercise not found.");

                return Ok(programExercise);
        }

        //============================
        // POST: api/ProgramExercise
        // Trainer only
        [HttpPost]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> CreateProgramExercise(ProgramExerciseInputDTO dto)
        {
            await _programExerciseService.CreateProgramExercise(dto);

            return Ok("Program Exercise created successfully.");
        }

        //============================
        // PUT: api/ProgramExercise/{id}
        // Trainer only
        [HttpPut("{id}")]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> UpdateProgramExercise(int id, ProgramExerciseInputDTO dto)
        {
            var result = await _programExerciseService.UpdateProgramExercise(id, dto);

            if (!result)

                return NotFound("Program Exercise not found.");

                return Ok("Program Exercise updated successfully.");
        }

        //============================
        // DELETE: api/ProgramExercise/{id}
        // Trainer only
        [HttpDelete("{id}")]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> DeleteProgramExercise(int id)
        {
            var result = await _programExerciseService.DeleteProgramExercise(id);

            if (!result)

                return NotFound("Program Exercise not found.");

                return Ok("Program Exercise deleted successfully.");
        }
    }
}
