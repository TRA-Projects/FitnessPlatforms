using FitnessPlatform.Models;

namespace FitnessPlatform.Repos.Interfaces
{
    public interface IExerciseRepository
    {
        // Get all exercises
        Task<IEnumerable<Exercise>> GetAllExercises();

        // Get exercise by id
        Task<Exercise?> GetExerciseById(int id);

        // Create new exercise
        Task<Exercise> CreateExercise(Exercise exercise);

        // Update exercise
        Task UpdateExercise(Exercise exercise);

        // Delete exercise
        Task DeleteExercise(int id);
    }
}
