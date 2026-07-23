using FitnessPlatform.Models;
using FitnessPlatform.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessPlatform.Repos
{
    public class TrainerRepo : ITrainerRepository
    {

        private readonly FitnessContext _context;

        public TrainerRepo(FitnessContext context)
        {
            _context = context;
        }

        // get all trainers

        public async Task<IEnumerable<Trainer>> GetAllTrainers()
        {
            return await _context.Trainers
                .ToListAsync();
        }

        // Get trainer by id
        public async Task<Trainer?> GetTrainerById(int id)
        {
            return await _context.Trainers
                .FirstOrDefaultAsync(t => t.traninerId == id);
        }
        // Create trainer
        public async Task<Trainer> CreateTrainer(Trainer trainer)
        {
            _context.Trainers.Add(trainer);

            await _context.SaveChangesAsync();

            return trainer;
        }
        // Update trainer
        public async Task UpdateTrainer(Trainer trainer)
        {
            _context.Trainers.Update(trainer);

            await _context.SaveChangesAsync();
        }

        // Delete trainer
        public async Task DeleteTrainer(int id)
        {
            var trainer = await GetTrainerById(id);

            if (trainer != null)
            {
                _context.Trainers.Remove(trainer);

                await _context.SaveChangesAsync();
            }
        }


    }
}
