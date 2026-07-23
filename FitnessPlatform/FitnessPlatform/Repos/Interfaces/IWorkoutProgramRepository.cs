using FitnessPlatform.Models;//use class and this class found in model folder

namespace FitnessPlatform.Repos.Interfaces//namespace mean the file Topic
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
