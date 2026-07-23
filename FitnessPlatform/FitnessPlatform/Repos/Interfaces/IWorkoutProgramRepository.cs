using FitnessPlatform.Models;

namespace FitnessPlatform.Repos.Interfaces
{
    public interface IWorkoutProgramRepository
    {
        // Get all workout programs
        Task<IEnumerable<WorkoutProgram>> GetAllWorkoutPrograms();

        // Get workout program by id
        Task<WorkoutProgram?> GetWorkoutProgramById(int id);

        // Create workout program
        Task<WorkoutProgram> CreateWorkoutProgram(
            WorkoutProgram workoutProgram);

        // Update workout program
        Task UpdateWorkoutProgram(
            WorkoutProgram workoutProgram);

        // Delete workout program
        Task DeleteWorkoutProgram(int id);
    }
}
