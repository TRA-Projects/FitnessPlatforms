using FitnessPlatform.Models;

namespace FitnessPlatform.Repos.Interfaces
{
    public interface IProgramExerciseRepository
    {
        // Get all program exercises
        Task<IEnumerable<ProgramExercise>> GetAllProgramExercises();

        // Get program exercise by id
        Task<ProgramExercise?> GetProgramExerciseById(int id);

        // Create program exercise
        Task<ProgramExercise> CreateProgramExercise(ProgramExercise programExercise);

        // Update program exercise
        Task UpdateProgramExercise(ProgramExercise programExercise);

        // Delete program exercise
        Task DeleteProgramExercise(int id);
    }
}
