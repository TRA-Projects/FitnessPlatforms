using FitnessPlatform.Models;

namespace FitnessPlatform.Repos.Interfaces
{
    public interface INutritionPlanRepository
    {
        // Get all nutrition plans
        Task<IEnumerable<NutritionPlan>> GetAllNutritionPlans();

        // Get nutrition plan by id
        Task<NutritionPlan?> GetNutritionPlanById(int id);

        // Get nutrition plans by member id
        Task<IEnumerable<NutritionPlan>> GetNutritionPlansByMemberId(int memberId);

        // Create new nutrition plan
        Task<NutritionPlan> CreateNutritionPlan(
            NutritionPlan nutritionPlan);

        // Update nutrition plan
        Task UpdateNutritionPlan(NutritionPlan nutritionPlan);

        // Delete nutrition plan
        Task DeleteNutritionPlan(int id);
    }
}
