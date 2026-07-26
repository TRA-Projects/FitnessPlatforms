using FitnessPlatform.DTOs;
using FitnessPlatform.Models;
using FitnessPlatform.Repos;
using FitnessPlatform.Repos.Interfaces;

namespace FitnessPlatform.Services
{
    public class TrainerService
    {
        private readonly ITrainerRepository _trainerRepository;

        public TrainerService(ITrainerRepository trainerRepository)
        {
            _trainerRepository = trainerRepository;

        }

        // Get all trainers
        public async Task<IEnumerable<TrainerOutputDTOs>> GetAllTrainers()
        {
            var trainers = await _trainerRepository.GetAllTrainers();

            return trainers.Select(t => new TrainerOutputDTOs
            {
                trainerId = t.traninerId,
                fullName = t.fullName,
                specialization = t.specialization
            });

        }
              // Create trainer
        public async Task CreateTrainer(TrainerInputDTOs dto)
        {
            Trainer trainer = new Trainer
            {
                fullName = dto.fullName,
                specialization = dto.specialization,
                yearsOfExperience = dto.yearsOfExperience,
                phoneNumber = dto.phoneNumber,
               
            };

            await _trainerRepository.CreateTrainer(trainer);
        }

        // Update trainer
        public async Task<bool> UpdateTrainer(int id, TrainerInputDTOs dto)
        {
            var trainer = await _trainerRepository.GetTrainerById(id);

            if (trainer == null)
                return false;

            trainer.fullName = dto.fullName;
            trainer.specialization = dto.specialization;
            trainer.yearsOfExperience = dto.yearsOfExperience;
            trainer.phoneNumber = dto.phoneNumber;
         

            await _trainerRepository.UpdateTrainer(trainer);

            return true;
        }
        // Delete trainer
        public async Task<bool> DeleteTrainer(int id)
        {
            var trainer = await _trainerRepository.GetTrainerById(id);

            if (trainer == null)
                return false;

            await _trainerRepository.DeleteTrainer(id);

            return true;
        }

    }
    
}
