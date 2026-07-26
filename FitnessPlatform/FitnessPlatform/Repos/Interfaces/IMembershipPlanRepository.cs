using FitnessPlatform.Models;

namespace FitnessPlatform.Repos.Interfaces
{
    public interface IMembershipPlanRepository
    {
        Task<IEnumerable<MembershipPlan>> GetAllMembershipPlans();

        Task<MembershipPlan?> GetMembershipPlanById(int id);

        Task<MembershipPlan> CreateMembershipPlan(MembershipPlan plan);

        Task UpdateMembershipPlan(MembershipPlan plan);

        Task DeleteMembershipPlan(int id);
    }
}