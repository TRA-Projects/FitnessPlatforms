using FitnessPlatform.DTOs;
using FitnessPlatform.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramExerciseController : ControllerBase
    {
        private readonly ProgramExerciseService _programExerciseService;


        public ProgramExerciseController(ProgramExerciseService programExerciseService)
        {
            _programExerciseService = programExerciseService;
        }

        //============================
        // GET: api/ProgramExercise
        [HttpGet]
        public async Task<IActionResult> GetAllProgramExercises()
        {
            var programExercises = await _programExerciseService.GetAllProgramExercises();

            return Ok(programExercises);
        }

        //============================
        // GET: api/ProgramExercise/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgramExerciseById(int id)
        {
            var programExercise = await _programExerciseService.GetProgramExerciseById(id);


            if (programExercise == null)

                return NotFound("Program Exercise not found.");

                return Ok(programExercise);
        }

        //============================
        // POST: api/ProgramExercise
        [HttpPost]
        public async Task<IActionResult> CreateProgramExercise(ProgramExerciseInputDTO dto)
        {
            await _programExerciseService.CreateProgramExercise(dto);

            return Ok("Program Exercise created successfully.");
        }

        //============================
        // PUT: api/ProgramExercise/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProgramExercise(int id, ProgramExerciseInputDTO dto)
        {
            var result = await _programExerciseService.UpdateProgramExercise(id, dto);

            if (!result)

                return NotFound("Program Exercise not found.");

                return Ok("Program Exercise updated successfully.");
        }

        //============================
        // DELETE: api/ProgramExercise/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgramExercise(int id)
        {
            var result = await _programExerciseService.DeleteProgramExercise(id);

            if (!result)

                return NotFound("Program Exercise not found.");

                return Ok("Program Exercise deleted successfully.");
        }
    }
}
