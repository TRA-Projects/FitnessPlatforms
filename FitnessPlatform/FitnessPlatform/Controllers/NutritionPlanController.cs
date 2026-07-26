using FitnessPlatform.DTOs;
using FitnessPlatform.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPlatform.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class NutritionPlanController : ControllerBase
    {
        private readonly NutritionPlanService _nutritionPlanService;

        public NutritionPlanController(NutritionPlanService nutritionPlanService)
        {
            _nutritionPlanService = nutritionPlanService;
        }

        // GET: api/NutritionPlan
        [HttpGet]
        public async Task<IActionResult> GetAllNutritionPlans()
        {
            var plans = await _nutritionPlanService.GetAllNutritionPlans();
            return Ok(plans);
        }

        // GET: api/NutritionPlan/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNutritionPlanById(int id)
        {
            var plan = await _nutritionPlanService.GetNutritionPlanById(id);

            if (plan == null)
                return NotFound();

            return Ok(plan);
        }

        // POST: api/NutritionPlan
        [HttpPost]
        public async Task<IActionResult> CreateNutritionPlan([FromBody] NutritionPlanInputDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _nutritionPlanService.CreateNutritionPlan(dto);

            return Ok("Nutrition plan created successfully.");
        }

        // PUT: api/NutritionPlan/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNutritionPlan(int id, [FromBody] NutritionPlanInputDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _nutritionPlanService.UpdateNutritionPlan(id, dto);

            if (!result)
                return NotFound();

            return Ok("Nutrition plan updated successfully.");
        }

        // DELETE: api/NutritionPlan/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNutritionPlan(int id)
        {
            var result = await _nutritionPlanService.DeleteNutritionPlan(id);

            if (!result)
                return NotFound();

            return Ok("Nutrition plan deleted successfully.");
        }
    }
}
    
