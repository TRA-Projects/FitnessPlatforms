using FitnessPlatform.DTOs;
using FitnessPlatform.Models;
using FitnessPlatform.Repos;
using FitnessPlatform.Repos.Interfaces;

namespace FitnessPlatform.Services
{
    public class ProgramExerciseService
    {
        private readonly ProgramExerciseRepo _programExerciseRepository;

        public ProgramExerciseService(ProgramExerciseRepo programExerciseRepository)
        {
            _programExerciseRepository = programExerciseRepository;
        }

        //==========================
        // Get all program exercises
        public async Task<IEnumerable<ProgramExerciseOutputDTO>> GetAllProgramExercises()
        {
            var programExercises = await _programExerciseRepository.GetAllProgramExercises();

            return programExercises.Select(pe => new ProgramExerciseOutputDTO
            {
                programExerciseId = pe.programExerciseId,
                exerciseName = pe.Exercise.exerciseName,
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
            var programExercise = await _programExerciseRepository.GetProgramExerciseById(id);

            if (programExercise == null)
                return null;

            return new ProgramExerciseDetailsDTO
            {
                programExerciseId = programExercise.programExerciseId,
                programId = programExercise.programId,
                exerciseId = programExercise.exerciseId,
                exerciseName = programExercise.Exercise.exerciseName,
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
            ProgramExercise programExercise = new ProgramExercise
            {
                programId = dto.programId,
                exerciseId = dto.exerciseId,
                sets = dto.sets,
                repetitions = dto.repetitions,
                dayOfWeek = dto.dayOfWeek,
                restTime = dto.restTime
            };

            await _programExerciseRepository.CreateProgramExercise(programExercise);
        }

        //==========================
        // Update program exercise
        public async Task<bool> UpdateProgramExercise(int id, ProgramExerciseInputDTO dto)
        {
            var programExercise = await _programExerciseRepository.GetProgramExerciseById(id);

            if (programExercise == null)
                return false;

            programExercise.programId = dto.programId;
            programExercise.exerciseId = dto.exerciseId;
            programExercise.sets = dto.sets;
            programExercise.repetitions = dto.repetitions;
            programExercise.dayOfWeek = dto.dayOfWeek;
            programExercise.restTime = dto.restTime;

            await _programExerciseRepository.UpdateProgramExercise(programExercise);

            return true;
        }

        //==========================
        // Delete program exercise
        public async Task<bool> DeleteProgramExercise(int id)
        {
            var programExercise = await _programExerciseRepository.GetProgramExerciseById(id);

            if (programExercise == null)
                return false;

            await _programExerciseRepository.DeleteProgramExercise(id);

            return true;
        }
    }
}
