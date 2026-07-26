using FitnessPlatform.DTOs;
using FitnessPlatform.Models;
using FitnessPlatform.Repos;
using FitnessPlatform.Repos.Interfaces;

namespace FitnessPlatform.Services
{
    public class ExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseService(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        //===========================================
        // Get all exercises
        public async Task<IEnumerable<ExerciseOutputDTO>> GetAllExercises()
        {
            var exercises = await _exerciseRepository.GetAllExercises();

            return exercises.Select(e => new ExerciseOutputDTO
            {
                exerciseId = e.exerciseId,
                exerciseName = e.exerciseName,
                targetMuscle = e.targetMuscle
            });
        }

        //===========================================
        // Get exercise by id
        public async Task<ExerciseDetailsDTO?> GetExerciseById(int id)
        {
            var exercise = await _exerciseRepository.GetExerciseById(id);

            if (exercise == null)
                return null;

            return new ExerciseDetailsDTO
            {
                exerciseId = exercise.exerciseId,
                exerciseName = exercise.exerciseName,
                targetMuscle = exercise.targetMuscle,
                videoUrl = exercise.videoUrl,
                equipment = exercise.equipment,
                difficultyLevel = exercise.difficulityLevel
            };
        }

        //===========================================
        // Create exercise
        public async Task CreateExercise(ExerciseInputDTO dto)
        {
            Exercise exercise = new Exercise
            {
                exerciseName = dto.exerciseName,
                targetMuscle = dto.targetMuscle,
                videoUrl = dto.videoUrl,
                equipment = dto.erquipment,
                difficulityLevel = dto.difficultyLevel
            };

            await _exerciseRepository.CreateExercise(exercise);
        }

        //===========================================
        // Update exercise
        public async Task<bool> UpdateExercise(int id, ExerciseInputDTO dto)
        {
            var exercise = await _exerciseRepository.GetExerciseById(id);

            if (exercise == null)
                return false;

            exercise.exerciseName = dto.exerciseName;
            exercise.targetMuscle = dto.targetMuscle;
            exercise.videoUrl = dto.videoUrl;
            exercise.equipment = dto.erquipment;
            exercise.difficulityLevel = dto.difficultyLevel;

            await _exerciseRepository.UpdateExercise(exercise);

            return true;
        }

        //===========================================
        // Delete exercise
        public async Task<bool> DeleteExercise(int id)
        {
            var exercise = await _exerciseRepository.GetExerciseById(id);

            if (exercise == null)
                return false;

            await _exerciseRepository.DeleteExercise(id);

            return true;
        }
    }
}
