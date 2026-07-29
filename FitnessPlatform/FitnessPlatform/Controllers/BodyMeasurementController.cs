using FitnessPlatform.Services;
using Microsoft.AspNetCore.Mvc;
using static FitnessPlatform.DTOs.BodyMeasurementDTOs;

namespace FitnessPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodyMeasurementController : ControllerBase
    {
        private readonly BodyMeasurementService _service;


        public BodyMeasurementController(
            BodyMeasurementService service)
        {
            _service = service;
        }

        // GET: api/BodyMeasurement
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllBodyMeasurements();

            return Ok(result);
        }


        // GET: api/BodyMeasurement/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetBodyMeasurementById(id);


            if (result == null)
                return NotFound();


            return Ok(result);
        }
        // GET: api/BodyMeasurement/member/3
        [HttpGet("member/{memberId:int}")]
        public async Task<IActionResult> GetByMemberId(int memberId)
        {
            var result = await _service.GetMeasurementsByMemberId(memberId);
            return Ok(result);
        }
        // POST: api/BodyMeasurement
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BodyMeasurementInputDTO dto)
        {
            var createdId = await _service.CreateBodyMeasurement(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdId },
                new { message = "Body measurement created successfully", id = createdId }
            );
        }

        // PUT: api/BodyMeasurement/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] BodyMeasurementInputDTO dto)
        {
            var success = await _service.UpdateBodyMeasurement(id, dto);

            if (!success)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/BodyMeasurement/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteBodyMeasurement(id);

            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}

