using FitnessPlatform.DTOs;
using FitnessPlatform.Models;
using FitnessPlatform.Repos;
using FitnessPlatform.Repos.Interfaces;


namespace FitnessPlatform.Services
{
    //====================================================
    // Service responsible for handling Nutrition Plan logic.
    // It converts data between DTOs and Models and
    // communicates with the Repository layer.
    //====================================================
    public class NutritionPlanService
    {
        // Repository used to access NutritionPlan data
        private readonly INutritionPlanRepository _nutritionPlanRepo;

        // Constructor Injection
        public NutritionPlanService(INutritionPlanRepository nutritionPlanRepo)
        {
            _nutritionPlanRepo = nutritionPlanRepo;
        }

        //====================================================
        // Retrieve all nutrition plans
        // Convert Model objects into Output DTOs
        //====================================================
        public async Task<IEnumerable<NutritionPlanOutputDTO>> GetAllNutritionPlans()
        {
            var plans = await _nutritionPlanRepo.GetAllNutritionPlans();

            return plans.Select(p => new NutritionPlanOutputDTO
            {
                nutritionPlanId = p.nutritionPlanId,
                planName = p.planName,
                fullName = p.Member.fullName,
                trainerName = p.Trainer.fullName
            });
        }

        //====================================================
        // Retrieve a nutrition plan by ID
        // Return detailed information as DetailsDTO
        //====================================================
        public async Task<NutritionPlanDetailsDTO?> GetNutritionPlanById(int id)
        {
            var plan = await _nutritionPlanRepo.GetNutritionPlanById(id);

            if (plan == null)
                return null;

            return new NutritionPlanDetailsDTO
            {
                nutritionPlanId = plan.nutritionPlanId,
                planName = plan.planName,
                dailyCalories = plan.dailyCalories,
                proteinGrams = plan.proteinGrams,
                carbsGrams = plan.carbsGrams,
                fatGrams = plan.fatGrams,
                notes = plan.notes,
                memberName = plan.Member.fullName,
                trainerName = plan.Trainer.fullName
            };
        }

        //====================================================
        // Create a new nutrition plan
        // Convert InputDTO into Model before saving
        //====================================================
        public async Task CreateNutritionPlan(NutritionPlanInputDTO dto)
        {
            NutritionPlan plan = new NutritionPlan
            {
                planName = dto.planName,
                dailyCalories = dto.dailyCalories,
                proteinGrams = dto.proteinGrams,
                carbsGrams = dto.carbsGrams,
                fatGrams = dto.fatGrams,
                notes = dto.notes,
                memberId = dto.memberId,
                trainerId = dto.trainerId
            };

            await _nutritionPlanRepo.CreateNutritionPlan(plan);
        }

        //====================================================
        // Update an existing nutrition plan
        // Returns false if the plan does not exist
        //====================================================
        public async Task<bool> UpdateNutritionPlan(int id, NutritionPlanInputDTO dto)
        {
            var plan = await _nutritionPlanRepo.GetNutritionPlanById(id);

            if (plan == null)
                return false;

            plan.planName = dto.planName;
            plan.dailyCalories = dto.dailyCalories;
            plan.proteinGrams = dto.proteinGrams;
            plan.carbsGrams = dto.carbsGrams;
            plan.fatGrams = dto.fatGrams;
            plan.notes = dto.notes;
            plan.memberId = dto.memberId;
            plan.trainerId = dto.trainerId;

            await _nutritionPlanRepo.UpdateNutritionPlan(plan);

            return true;
        }

        //====================================================
        // Delete a nutrition plan by ID
        // Returns false if the plan does not exist
        //====================================================
        public async Task<bool> DeleteNutritionPlan(int id)
        {
            var plan = await _nutritionPlanRepo.GetNutritionPlanById(id);

            if (plan == null)
                return false;

            await _nutritionPlanRepo.DeleteNutritionPlan(id);

            return true;
        }
    }
}
