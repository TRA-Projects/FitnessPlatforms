using FitnessPlatform.Services;
using Microsoft.AspNetCore.Mvc;
using static FitnessPlatform.DTOs.SubscriptionDTOs;

namespace FitnessPlatform.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class SubscriptionController : ControllerBase
        {
            private readonly SubscriptionService _subscriptionService;

            public SubscriptionController(SubscriptionService subscriptionService)
            {
                _subscriptionService = subscriptionService;
            }


            // GET: api/Subscription
            [HttpGet]
            public async Task<IActionResult> GetAllSubscriptions()
            {
                var subscriptions = await _subscriptionService.GetAllSubscriptions();

                return Ok(subscriptions);
            }
            // GET: api/Subscription/5
            [HttpGet("{id}")]
            public async Task<IActionResult> GetSubscriptionById(int id)
            {
                var subscription = await _subscriptionService.GetSubscriptionById(id);

                if (subscription == null)
                    return NotFound();

                return Ok(subscription);
            }

            // POST: api/Subscription
            [HttpPost]
            public async Task<IActionResult> CreateSubscription(SubscriptionInputDTO dto)
            {
                await _subscriptionService.CreateSubscription(dto);

                return Ok("Subscription created successfully");
            }

            // PUT: api/Subscription/5
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateSubscription(
                int id,
                SubscriptionInputDTO dto)
            {
                var result = await _subscriptionService.UpdateSubscription(id, dto);

                if (!result)
                    return NotFound();

                return Ok("Subscription updated successfully");
            }

            // DELETE: api/Subscription/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteSubscription(int id)
            {
                var result = await _subscriptionService.DeleteSubscription(id);

                if (!result)
                    return NotFound();

                return Ok("Subscription deleted successfully");
            }
        }
}

