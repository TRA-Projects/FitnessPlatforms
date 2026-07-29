using FitnessPlatform.Models;
using FitnessPlatform.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessPlatform.Repos
{
    //
    public class NutritionPlanRepo : INutritionPlanRepository
    {
        // Repository responsible for performing CRUD operations
        // for Nutrition Plans using Entity Framework Core.

        private readonly FitnessContext _context;

        //Initializes a new instance of the repository
        public NutritionPlanRepo(FitnessContext context)
        {
            _context = context;
        }


        // Get all nutrition plans
        //Retrieves all nutrition plans with their related Member and Trainer.
        public async Task<IEnumerable<NutritionPlan>> GetAllNutritionPlans()
        {
            return await _context.NutritionPlans
                .Include(n => n.Member)
                .Include(n => n.Trainer)
                .ToListAsync();
        }


        // Get nutrition plan by id
        //Includes related Member and Trainer information.
        //
        public async Task<NutritionPlan?> GetNutritionPlanById(int id)
        {
            return await _context.NutritionPlans
                .Include(n => n.Member)
                .Include(n => n.Trainer)
                .FirstOrDefaultAsync(n => n.nutritionPlanId == id);
        }


        // Get nutrition plans for specific member
        public async Task<IEnumerable<NutritionPlan>> GetNutritionPlansByMemberId(
            int memberId)
        {
            return await _context.NutritionPlans
                .Where(n => n.memberId == memberId)
                .ToListAsync();
        }


        // Creates a new nutrition plan and saves it to the database.
        public async Task<NutritionPlan> CreateNutritionPlan(
            NutritionPlan nutritionPlan)
        {
            _context.NutritionPlans.Add(nutritionPlan);

            await _context.SaveChangesAsync();

            return nutritionPlan;
        }


        // Updates an existing nutrition plan.
        public async Task UpdateNutritionPlan(
            NutritionPlan nutritionPlan)
        {
            _context.NutritionPlans.Update(nutritionPlan);

            await _context.SaveChangesAsync();
        }


        // Deletes a nutrition plan by its ID if it exists.
        public async Task DeleteNutritionPlan(int id)
        {
            var plan = await GetNutritionPlanById(id);

            if (plan != null)
            {
                _context.NutritionPlans.Remove(plan);

                await _context.SaveChangesAsync();
            }
        }
    }
}
