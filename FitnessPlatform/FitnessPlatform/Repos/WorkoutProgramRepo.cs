using FitnessPlatform.Models;
using FitnessPlatform.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;



namespace FitnessPlatform.Repos
{
    public class WorkoutProgramRepo : IWorkoutProgramRepository
    {
        private readonly FitnessContext _context;


        public WorkoutProgramRepo(FitnessContext context)
        {
            _context = context;
        }


        // Get all workout programs
        public async Task<IEnumerable<WorkoutProgram>> GetAllWorkoutPrograms()
        {
            return await _context.WorkoutPrograms
                .Include(w => w.Member)
                .Include(w => w.ProgramExercises)
                .ToListAsync();
        }


        // Get workout program by id
        public async Task<WorkoutProgram?> GetWorkoutProgramById(int id)
        {
            return await _context.WorkoutPrograms
                .Include(w => w.Member)
                .Include(w => w.ProgramExercises)
                .FirstOrDefaultAsync(w => w.programId == id);
        }

        // Create workout program
        public async Task<WorkoutProgram> CreateWorkoutProgram(
            WorkoutProgram workoutProgram)
        {
            _context.WorkoutPrograms.Add(workoutProgram);

            await _context.SaveChangesAsync();

            return workoutProgram;
        }


        // Update workout program
        public async Task UpdateWorkoutProgram(
            WorkoutProgram workoutProgram)
        {
            _context.WorkoutPrograms.Update(workoutProgram);

            await _context.SaveChangesAsync();
        }


        // Delete workout program
        public async Task DeleteWorkoutProgram(int id)
        {
            var program = await GetWorkoutProgramById(id);

            if (program != null)
            {
                _context.WorkoutPrograms.Remove(program);

                await _context.SaveChangesAsync();
            }
        }

    }
}
