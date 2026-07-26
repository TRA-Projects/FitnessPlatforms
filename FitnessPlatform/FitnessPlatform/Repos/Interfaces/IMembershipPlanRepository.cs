using FitnessPlatform.Models;

namespace FitnessPlatform.Repos.Interfaces
{
    public class IMembershipPlanRepository
    {
        public interface IMembershipPlanRepos
        {
            // Get all membership plans
            Task<IEnumerable<MembershipPlan>> GetAllMembershipPlans();

            // Get membership plan by id
            Task<MembershipPlan?> GetMembershipPlanById(int id);

            // Create membership plan
            Task<MembershipPlan> CreateMembershipPlan(MembershipPlan plan);

            // Update membership plan
            Task UpdateMembershipPlan(MembershipPlan plan);

            // Delete membership plan
            Task DeleteMembershipPlan(int id);
        }

    }
}
