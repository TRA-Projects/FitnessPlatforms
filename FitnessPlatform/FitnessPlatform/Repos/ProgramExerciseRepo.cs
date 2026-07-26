using FitnessPlatform.Models;
using FitnessPlatform.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessPlatform.Repos
{
    public class ProgramExerciseRepo : IProgramExerciseRepository
    {

        private readonly FitnessContext _context;

        public ProgramExerciseRepo(FitnessContext context)
        {
            _context = context;
        }

        //==========================
        // Get all program exercises

        public async Task<IEnumerable<ProgramExercise>> GetAllProgramExercises()
        {
            return await _context.ProgramExercises
                .Include(pe => pe.WorkoutProgram)
                .Include(pe => pe.Exercise)
                .ToListAsync();
        }

        //==========================
        // Get program exercise by id
        public async Task<ProgramExercise?> GetProgramExerciseById(int id)
        {
            return await _context.ProgramExercises
                .Include(pe => pe.WorkoutProgram)
                .Include(pe => pe.Exercise)
                .FirstOrDefaultAsync(pe => pe.programExerciseId == id);
        }

        //==========================
        // Create new program exercise
        public async Task<ProgramExercise> CreateProgramExercise(
            ProgramExercise programExercise)
        {
            _context.ProgramExercises.Add(programExercise);

            await _context.SaveChangesAsync();

            return programExercise;
        }

        //============================
        // Update program exercise
        public async Task UpdateProgramExercise(
            ProgramExercise programExercise)
        {
            _context.ProgramExercises.Update(programExercise);

            await _context.SaveChangesAsync();
        }

        //============================
        // Delete program exercise
        public async Task DeleteProgramExercise(int id)
        {
            var programExercise = await GetProgramExerciseById(id);

            if (programExercise != null)
            {
                _context.ProgramExercises.Remove(programExercise);

                await _context.SaveChangesAsync();
            }
        }
    }
}
