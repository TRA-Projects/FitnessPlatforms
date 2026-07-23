using FitnessPlatform.Models;
using FitnessPlatform.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessPlatform.Repos
{
    public class NutritionPlanRepo : INutritionPlanRepository
    {

        private readonly FitnessContext _context;


        public NutritionPlanRepo(FitnessContext context)
        {
            _context = context;
        }


        // Get all nutrition plans
        public async Task<IEnumerable<NutritionPlan>> GetAllNutritionPlans()
        {
            return await _context.NutritionPlans
                .Include(n => n.Member)
                .ToListAsync();
        }


        // Get nutrition plan by id
        public async Task<NutritionPlan?> GetNutritionPlanById(int id)
        {
            return await _context.NutritionPlans
                .Include(n => n.Member)
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


        // Create nutrition plan
        public async Task<NutritionPlan> CreateNutritionPlan(
            NutritionPlan nutritionPlan)
        {
            _context.NutritionPlans.Add(nutritionPlan);

            await _context.SaveChangesAsync();

            return nutritionPlan;
        }


        // Update nutrition plan
        public async Task UpdateNutritionPlan(
            NutritionPlan nutritionPlan)
        {
            _context.NutritionPlans.Update(nutritionPlan);

            await _context.SaveChangesAsync();
        }


        // Delete nutrition plan
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
