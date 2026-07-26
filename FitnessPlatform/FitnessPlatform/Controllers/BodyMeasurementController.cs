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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetBodyMeasurementById(id);


            if (result == null)
                return NotFound();


            return Ok(result);
        }

        // POST: api/BodyMeasurement
        [HttpPost]
        public async Task<IActionResult> Create(
            BodyMeasurementInputDTO dto)
        {
            await _service.CreateBodyMeasurement(dto);

            return Ok("Body measurement created successfully");
        }

        // PUT: api/BodyMeasurement/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            BodyMeasurementInputDTO dto)
        {
            var result = await _service.UpdateBodyMeasurement(id, dto);


            if (!result)
                return NotFound();


            return Ok("Body measurement updated successfully");
        }

        // DELETE: api/BodyMeasurement/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteBodyMeasurement(id);


            if (!result)
                return NotFound();


            return Ok("Body measurement deleted successfully");
        }

    }
}

