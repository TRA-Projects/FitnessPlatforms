using FitnessPlatform.Models;

namespace FitnessPlatform.Repos.Interfaces
{
    public interface ITrainerRepository
    {

        // Get all trainers
        Task<IEnumerable<Trainer>> GetAllTrainers();

        // Get trainer by id
        Task<Trainer?> GetTrainerById(int id);

        // Create new trainer
        Task<Trainer> CreateTrainer(Trainer trainer);

        // Update trainer
        Task UpdateTrainer(Trainer trainer);

        // Delete trainer
        Task DeleteTrainer(int id);
    }
}
