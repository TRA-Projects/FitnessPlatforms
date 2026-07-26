using FitnessPlatform.Models;
using FitnessPlatform.Repos;
using FitnessPlatform.Repos.Interfaces;
using static FitnessPlatform.DTOs.MembershipPlanDTOs;

namespace FitnessPlatform.Services
{
    public class MembershipPlanService
    {
        private readonly IMembershipPlanRepository _membershipPlanRepository;

        public MembershipPlanService(IMembershipPlanRepository membershipPlanRepository)
        {
            _membershipPlanRepository = membershipPlanRepository;
        }

        // Get all membership plans
        public async Task<IEnumerable<MembershipPlanOutputDTO>> GetAllPlans()
        {
            var plans = await _membershipPlanRepository.GetAllMembershipPlans();

            return plans.Select(p => new MembershipPlanOutputDTO
            {
                planId = p.planId,
                planName = p.planName,
                price = p.price
            });
        }

       

        // Create membership plan
        public async Task CreatePlan(MembershipPlanInputDTO dto)
        {
            MembershipPlan plan = new MembershipPlan
            {
                planName = dto.planName,
                price = dto.price,
                durationInDays = dto.durationInDays,
                Description = dto.description
            };

            await _membershipPlanRepository.CreateMembershipPlan(plan);
        }

        // Update membership plan
        public async Task<bool> UpdatePlan(int id, MembershipPlanInputDTO dto)
        {
            var plan = await _membershipPlanRepository.GetMembershipPlanById(id);

            if (plan == null)
                return false;

            plan.planName = dto.planName;
            plan.price = dto.price;
            plan.durationInDays = dto.durationInDays;
            plan.Description = dto.description;

            await _membershipPlanRepository.UpdateMembershipPlan(plan);

            return true;
        }

        // Delete membership plan
        public async Task<bool> DeletePlan(int id)
        {
            var plan = await _membershipPlanRepository.GetMembershipPlanById(id);

            if (plan == null)
                return false;

            await _membershipPlanRepository.DeleteMembershipPlan(id);

            return true;
        }
    }
}

