using FitnessPlatform.Models;
using FitnessPlatform.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessPlatform.Repos
{
    public class MembershipPlanRepo : IMembershipPlanRepository
    {

        private readonly FitnessContext _context;


        public MembershipPlanRepo(FitnessContext context)
        {
            _context = context;
        }
        // Get all membership plans
        public async Task<IEnumerable<MembershipPlan>> GetAllMembershipPlans()
        {
            return await _context.MembershipPlans
                .ToListAsync();
        }
        // Get membership plan by id
        public async Task<MembershipPlan?> GetMembershipPlanById(int id)
        {
            return await _context.MembershipPlans
                .FirstOrDefaultAsync(m => m.planId == id);
        }

        // Create membership plan
        public async Task<MembershipPlan> CreateMembershipPlan(
            MembershipPlan plan)
        {
            _context.MembershipPlans.Add(plan);

            await _context.SaveChangesAsync();

            return plan;
        }
        // Update membership plan
        public async Task UpdateMembershipPlan(
            MembershipPlan plan)
        {
            _context.MembershipPlans.Update(plan);

            await _context.SaveChangesAsync();
        }



        // Delete membership plan
        public async Task DeleteMembershipPlan(int id)
        {
            var plan = await GetMembershipPlanById(id);

            if (plan != null)
            {
                _context.MembershipPlans.Remove(plan);

                await _context.SaveChangesAsync();
            }
        }

    }
}
