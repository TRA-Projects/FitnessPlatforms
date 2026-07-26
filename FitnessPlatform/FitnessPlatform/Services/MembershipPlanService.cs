using FitnessPlatform.Models;
using FitnessPlatform.Repos;
using FitnessPlatform.Repos.Interfaces;
using static FitnessPlatform.DTOs.MembershipPlanDTOs;

namespace FitnessPlatform.Services
{
    public class MembershipPlanService
    {
        private readonly MembershipPlanRepo _membershipPlanRepository;

        public MembershipPlanService(MembershipPlanRepo membershipPlanRepository)
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
                durationInDays = dto.durationInMonths,
                Description = dto.description
            };

            await _membershipPlanRepository.CreateMembershipPlan(plan);
        }


    }
}

