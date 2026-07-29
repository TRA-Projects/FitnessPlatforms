using FitnessPlatform.DTOs;
using FitnessPlatform.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPlatform.Controllers
{
    [Route("api/[controller]")] // show the path of API => api/ProgramExercise
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
        // Admin + Member + Trainer
        [HttpGet]
        [Authorize(Roles = "Admin,Member,Trainer")]
        public async Task<IActionResult> GetAllProgramExercises()
        {
            var programExercises = await _programExerciseService.GetAllProgramExercises();

            return Ok(programExercises);
        }

        //============================
        // GET: api/ProgramExercise/{id}
        // Admin + Member + Trainer
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Member,Trainer")]
        public async Task<IActionResult> GetProgramExerciseById(int id)
        {
            var programExercise = await _programExerciseService.GetProgramExerciseById(id);


            if (programExercise == null)

                return NotFound("Program Exercise not found.");

                return Ok(programExercise);
        }

        //============================
        // POST: api/ProgramExercise
        // Admin + Trainer
        [HttpPost]
        [Authorize(Roles = "Admin,Trainer")]
        public async Task<IActionResult> CreateProgramExercise([FromBody] ProgramExerciseInputDTO dto)
        {
            await _programExerciseService.CreateProgramExercise(dto);

            return Ok("Program Exercise created successfully.");
        }

        //============================
        // PUT: api/ProgramExercise/{id}
        // Admin + Trainer
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Trainer")]
        public async Task<IActionResult> UpdateProgramExercise(int id, ProgramExerciseInputDTO dto)
        {
            var result = await _programExerciseService.UpdateProgramExercise(id, dto);

            if (!result)

                return NotFound("Program Exercise not found.");

                return Ok("Program Exercise updated successfully.");
        }

        //============================
        // DELETE: api/ProgramExercise/{id}
        // Admin + Trainer
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Trainer")]
        public async Task<IActionResult> DeleteProgramExercise(int id)
        {
            var result = await _programExerciseService.DeleteProgramExercise(id);

            if (!result)

                return NotFound("Program Exercise not found.");

                return Ok("Program Exercise deleted successfully.");
        }
    }
}
