using FitnessPlatform.DTOs;
using FitnessPlatform.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPlatform.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class NutritionPlanController : ControllerBase
    {
        private readonly NutritionPlanService _nutritionPlanService;

        // Constructor Injection
        public NutritionPlanController(NutritionPlanService nutritionPlanService)
        {
            _nutritionPlanService = nutritionPlanService;
        }


        //====================================================
        // GET: api/NutritionPlan
        // Retrieve all nutrition plans.
        // Accessible by Admin, Trainer and Member.
        //====================================================

        [HttpGet]
        [Authorize(Roles = "Admin,Trainer,Member")]
        public async Task<IActionResult> GetAllNutritionPlans()
        {
            var plans = await _nutritionPlanService.GetAllNutritionPlans();
            return Ok(plans);
        }

        //====================================================
        // GET: api/NutritionPlan/{id}
        // Retrieve a nutrition plan by its ID.
        // Accessible by Admin, Trainer and Member.
        //====================================================

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Trainer,Member")]
        public async Task<IActionResult> GetNutritionPlanById(int id)
        {
            var plan = await _nutritionPlanService.GetNutritionPlanById(id);

            if (plan == null)
                return NotFound();

            return Ok(plan);
        }

        //====================================================
        // POST: api/NutritionPlan
        // Create a new nutrition plan.
        // Accessible by Admin and Trainer only.
        //====================================================

        [HttpPost]
        [Authorize(Roles = "Admin,Trainer")]
        public async Task<IActionResult> CreateNutritionPlan([FromBody] NutritionPlanInputDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _nutritionPlanService.CreateNutritionPlan(dto);

            return Ok("Nutrition plan created successfully.");
        }

        //====================================================
        // PUT: api/NutritionPlan/{id}
        // Update an existing nutrition plan.
        // Accessible by Admin and Trainer only.
        //====================================================

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Trainer")]
        public async Task<IActionResult> UpdateNutritionPlan(int id, [FromBody] NutritionPlanInputDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _nutritionPlanService.UpdateNutritionPlan(id, dto);

            if (!result)
                return NotFound();

            return Ok("Nutrition plan updated successfully.");
        }

        //====================================================
        // DELETE: api/NutritionPlan/{id}
        // Delete a nutrition plan.
        // Accessible by Admin only.
        //====================================================

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteNutritionPlan(int id)
        {
            var result = await _nutritionPlanService.DeleteNutritionPlan(id);

            if (!result)
                return NotFound();

            return Ok("Nutrition plan deleted successfully.");
        }
    }
}
    
