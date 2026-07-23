using FitnessPlatform.Models;

namespace FitnessPlatform.Repos.Interfaces
{
    public interface IWorkoutSessionRepository
    {
        //Get all workout sessions
        Task<IEnumerable<WorkoutSession>> GetAllWorkoutSessionsAsync();

        // Get workout session by id
        Task<WorkoutSession?> GetWorkoutSessionByIdAsync(int id);

        // Get workout sessions by member id
        Task<IEnumerable<WorkoutSession>> GetWorkoutSessionsByMemberIdAsync(int memberId);

        // Create new workout session
        Task<WorkoutSession> CreateWorkoutSessionAsync(WorkoutSession workoutSession);

        // Update workout session
        Task<WorkoutSession> UpdateWorkoutSessionAsync(WorkoutSession workoutSession);

        // Delete workout session
        Task DeleteWorkoutSessionAsync(int id);

    }
}
