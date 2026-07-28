using FitnessPlatform.DTOs;
using FitnessPlatform.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // أي مستخدم مسجل دخول يستطيع الوصول بشكل عام
    public class MembershipPlanController : ControllerBase
    {
        private readonly MembershipPlanService _membershipPlanService;

        public MembershipPlanController(MembershipPlanService membershipPlanService)
        {
            _membershipPlanService = membershipPlanService;
        }

        // Get all membership plans
        // Member, Trainer, Admin
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var plans = await _membershipPlanService.GetAllPlans();

            return Ok(plans);
        }

        // Get membership plan by id
        // Member, Trainer, Admin
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var plan = await _membershipPlanService.GetPlanById(id);

            if (plan == null)
                return NotFound();

            return Ok(plan);
        }

        // Create membership plan
        // Admin only
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(MembershipPlanDTOs dto)
        {
            await _membershipPlanService.CreatePlan(dto);

            return Ok("Membership plan created successfully.");
        }

        // Update membership plan
        // Admin only
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MembershipPlanDTOs dto)
        {
            var result = await _membershipPlanService.UpdatePlan(id, dto);

            if (!result)
                return NotFound();

            return Ok("Membership plan updated successfully.");
        }

        // Delete membership plan
        // Admin only
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _membershipPlanService.DeletePlan(id);

            if (!result)
                return NotFound();

            return Ok("Membership plan deleted successfully.");
        }
    }
}