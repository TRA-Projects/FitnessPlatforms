using FitnessPlatform.Models;
using FitnessPlatform.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace FitnessPlatform.Repos
{
    public class ExerciseRepo : IExerciseRepository
    {
        private readonly FitnessContext _context;

        public ExerciseRepo (FitnessContext context)
        {
            _context = context;
        }

        //==================
        // Get all exercises
        public async Task<IEnumerable<Exercise>> GetAllExercises()
        {
            return await _context.Exercises.ToListAsync();
        }

        //==================
        // Get exercise by id
        public async Task <Exercise?> GetExerciseById(int id)
        {
            return await _context.Exercises.FirstOrDefaultAsync(e => e.exerciseId == id);
        }

        //==================
        // Add new exercise
        public async Task <Exercise> CreateExercise(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();
            return exercise;
        }

        //==================
        // Update exercise
        public async Task UpdateExercise(Exercise exercise)
        {
            _context.Exercises.Update(exercise);

            await _context.SaveChangesAsync();
        }

        //===================
        // Delete exercise
        public async Task DeleteExercise(int id)
        {
            var exercise = await GetExerciseById(id);

            if (exercise != null)
            {
                _context.Exercises.Remove(exercise);

                await _context.SaveChangesAsync();
            }
        }

    }
}
