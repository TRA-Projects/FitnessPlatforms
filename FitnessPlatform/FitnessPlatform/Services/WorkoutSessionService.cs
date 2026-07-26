using FitnessPlatform.DTOs;
using FitnessPlatform.Models;
using FitnessPlatform.Repos;
using FitnessPlatform.Repos.Interfaces;

namespace FitnessPlatform.Services
{

    //====================================================
    // Service responsible for handling Workout Session logic
    // It converts data between DTOs and Models and
    // communicates with the Repository layer.
    //====================================================
    public class WorkoutSessionService
    {

        // Repository used to access WorkoutSession data
        private readonly IWorkoutSessionRepository _workoutSessionRepo;

        // Constructor Injection
        public WorkoutSessionService(IWorkoutSessionRepository workoutSessionRepo)
        {
            _workoutSessionRepo = workoutSessionRepo;
        }

        //====================================================
        // Retrieve all workout sessions
        // Convert Model objects into Output DTOs
        //====================================================
        public async Task<IEnumerable<WorkoutSessionOutputDTO>> GetAllWorkoutSessions()
        {
            var sessions = await _workoutSessionRepo.GetAllWorkoutSessionsAsync();

            return sessions.Select(s => new WorkoutSessionOutputDTO
            {
                sessionId = s.sessionId,
                sessionDate = s.sessionDate,
                fullName = s.Member.fullName,
                programName = s.WorkoutProgram.programName,
                isCompleted = s.isCompleted
            });
        }

        //====================================================
        // Retrieve a workout session by ID
        // Return detailed information as DetailDTO
        //====================================================
        public async Task<WorkoutSessionDetailDTO?> GetWorkoutSessionById(int id)
        {
            var session = await _workoutSessionRepo.GetWorkoutSessionByIdAsync(id);

            if (session == null)
                return null;

            return new WorkoutSessionDetailDTO
            {
                sessionId = session.sessionId,
                sessionDate = session.sessionDate,
                durationInMinutes = session.durationInMinutes,
                caloriesBurned = session.caloriesBurned,
                isCompleted = session.isCompleted,
                fullName = session.Member.fullName,
                programName = session.WorkoutProgram.programName
            };
        }

        //====================================================
        // Create a new workout session
        //====================================================
        public async Task CreateWorkoutSession(WorkoutSessionInputDTO dto)
        {
            WorkoutSession session = new WorkoutSession
            {
                memberId = dto.memberId,
                programId = dto.programId,
                sessionDate = DateTime.Now,
                durationInMinutes = dto.durationInMinutes,

                // Example calculation (can be changed later)
                caloriesBurned = dto.durationInMinutes * 8,

                // New session starts as not completed
                isCompleted = false
            };

            await _workoutSessionRepo.CreateWorkoutSessionAsync(session);
        }

        //====================================================
        // Update an existing workout session
        // Returns false if the session does not exist
        //====================================================
        public async Task<bool> UpdateWorkoutSession(int id, WorkoutSessionInputDTO dto)
        {
            var session = await _workoutSessionRepo.GetWorkoutSessionByIdAsync(id);

            if (session == null)
                return false;

            session.memberId = dto.memberId;
            session.programId = dto.programId;
            session.durationInMinutes = dto.durationInMinutes;

            // Recalculate calories
            session.caloriesBurned = dto.durationInMinutes * 8;

            await _workoutSessionRepo.UpdateWorkoutSessionAsync(session);

            return true;
        }

        //====================================================
        // Delete a workout session by ID
        // Returns false if the session does not exist
        //====================================================
        public async Task<bool> DeleteWorkoutSession(int id)
        {
            var session = await _workoutSessionRepo.GetWorkoutSessionByIdAsync(id);

            if (session == null)
                return false;

            await _workoutSessionRepo.DeleteWorkoutSessionAsync(id);

            return true;
        }

    }
}