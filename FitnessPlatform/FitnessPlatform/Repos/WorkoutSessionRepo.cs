using FitnessPlatform.Repos.Interfaces;
using FitnessPlatform.Models;
using Microsoft.EntityFrameworkCore;


namespace FitnessPlatform.Repos
{
    public class WorkoutSessionRepo : IWorkoutSessionRepository
    {
        private readonly FitnessContext _context;

        public WorkoutSessionRepo(FitnessContext context)
        {
            _context = context;
        }

        // Get all workout sessions
        public async Task<IEnumerable<WorkoutSession>> GetAllWorkoutSessionsAsync()
        {
            return await _context.WorkoutSessions
                           .Include(w => w.Member)
                           .Include(w => w.WorkoutProgram)
                           .ToListAsync();
        }

        // Get workout session by id
        public async Task<WorkoutSession?> GetWorkoutSessionByIdAsync(int id)
        {
            return await _context.WorkoutSessions
                           .Include(w => w.Member)
                           .Include(w => w.WorkoutProgram)
                           .FirstOrDefaultAsync(w => w.sessionId == id);
        }

        // Get sessions for a specific member
        public async Task<IEnumerable<WorkoutSession>> GetWorkoutSessionsByMemberIdAsync(int memberId)
        {
            return await _context.WorkoutSessions
                           .Include(w => w.Member)
                           .Include(w => w.WorkoutProgram)
                           .Where(w => w.memberId == memberId)
                           .ToListAsync();
        }

        // Create new workout session
        public async Task<WorkoutSession> CreateWorkoutSessionAsync(WorkoutSession workoutSession)
        {
            _context.WorkoutSessions.Add(workoutSession);

            await _context.SaveChangesAsync();

            return workoutSession;
        }

        // Update workout session
        public async Task<WorkoutSession> UpdateWorkoutSessionAsync(WorkoutSession workoutSession)
        {
            _context.WorkoutSessions.Update(workoutSession);
            await _context.SaveChangesAsync();
            return workoutSession;
        }

        // Delete workout session
        public async Task DeleteWorkoutSessionAsync(int id)
        {
            var session = await GetWorkoutSessionByIdAsync(id);

            if (session != null)
            {
                _context.WorkoutSessions.Remove(session);

                await _context.SaveChangesAsync();
            }
        }
    }
}
