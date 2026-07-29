using FitnessPlatform.DTOs;
using FitnessPlatform.Models;
using FitnessPlatform.Repos;
using FitnessPlatform.Repos.Interfaces;

namespace FitnessPlatform.Services
{
    public class ProgramExerciseService
    {
        private readonly IProgramExerciseRepository _programExerciseRepository;

        public ProgramExerciseService(IProgramExerciseRepository programExerciseRepository)
        {
            _programExerciseRepository = programExerciseRepository;
        }

        //==========================
        // Get all program exercises
        public async Task<IEnumerable<ProgramExerciseOutputDTO>> GetAllProgramExercises()
        {
            // Review all program exercise records
            var programExercises = await _programExerciseRepository.GetAllProgramExercises();

            // Convert each entity into an Output DTO
            return programExercises.Select(pe => new ProgramExerciseOutputDTO
            {
                programExerciseId = pe.programExerciseId,
                exerciseName = pe.Exercise?.exerciseName ?? "N/A",
                sets = pe.sets,
                repetitions = pe.repetitions,
                dayOfWeek = pe.dayOfWeek,
                restTime = pe.restTime
            });
        }

        //==========================
        // Get program exercise by id
        public async Task<ProgramExerciseDetailsDTO?> GetProgramExerciseById(int id)
        {
            // Search for the program exercise
            var programExercise = await _programExerciseRepository.GetProgramExerciseById(id);

            if (programExercise == null)
                return null;

            return new ProgramExerciseDetailsDTO
            {
                programExerciseId = programExercise.programExerciseId,
                programId = programExercise.programId,
                exerciseId = programExercise.exerciseId,
                exerciseName = programExercise.Exercise?.exerciseName ?? "N/A",
                sets = programExercise.sets,
                repetitions = programExercise.repetitions,
                dayOfWeek = programExercise.dayOfWeek,
                restTime = programExercise.restTime
            };
        }

        //==========================
        // Create program exercise
        public async Task CreateProgramExercise(ProgramExerciseInputDTO dto)
        {
            // Create a new ProgramExercise entity
            ProgramExercise programExercise = new ProgramExercise
            {
                programId = dto.programId,
                exerciseId = dto.exerciseId,
                sets = dto.sets,
                repetitions = dto.repetitions,
                dayOfWeek = dto.dayOfWeek,
                restTime = dto.restTime
            };

            // Save the new record
            await _programExerciseRepository.CreateProgramExercise(programExercise);
        }

        //==========================
        // Update program exercise
        public async Task<bool> UpdateProgramExercise(int id, ProgramExerciseInputDTO dto)
        {
            // Find the program exercise by ID
            var programExercise = await _programExerciseRepository.GetProgramExerciseById(id);

            if (programExercise == null)
                return false;

            // Update the entity properties
            programExercise.programId = dto.programId;
            programExercise.exerciseId = dto.exerciseId;
            programExercise.sets = dto.sets;
            programExercise.repetitions = dto.repetitions;
            programExercise.dayOfWeek = dto.dayOfWeek;
            programExercise.restTime = dto.restTime;

            // Save the updated record
            await _programExerciseRepository.UpdateProgramExercise(programExercise);

            return true;
        }

        //==========================
        // Delete program exercise
        // Returns false if the record does not exist
        public async Task<bool> DeleteProgramExercise(int id)
        {
            // Find the program exercise first
            var programExercise = await _programExerciseRepository.GetProgramExerciseById(id);

            if (programExercise == null)
                return false;

            // Delete the record
            await _programExerciseRepository.DeleteProgramExercise(id);

            return true;
        }
    }
}
