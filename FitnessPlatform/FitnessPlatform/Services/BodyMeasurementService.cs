using FitnessPlatform.DTOs;
using FitnessPlatform.Models;
using FitnessPlatform.Repos;

namespace FitnessPlatform.Services
{
    public class BodyMeasurementService
    {
        private readonly BodyMeasurementRepo _bodyMeasurementRepo;

        public BodyMeasurementService(BodyMeasurementRepo bodyMeasurementRepo)
        {
            _bodyMeasurementRepo = bodyMeasurementRepo;
        }

        // Get all body measurements
        public async Task<IEnumerable<BodyMeasurementDTOs.BodyMeasurementOutputDTO>> GetAllBodyMeasurements()
        {
            var measurements = await _bodyMeasurementRepo.GetAllBodyMeasurements();

            return measurements.Select(m => new BodyMeasurementDTOs.BodyMeasurementOutputDTO
            {
                measurementId = m.measurementId,
                memberName = m.Member.fullName,
                measurementDate = m.measurementDate,
                weight = m.weight,
                bodyFatPercentage = m.bodyFatPercentage,
                waistCircumference = m.waistCircumference
            });
        }

        // Get body measurement by id
        public async Task<BodyMeasurementDTOs.BodyMeasurementDetailsDTO?> GetBodyMeasurementById(int id)
        {
            var measurement = await _bodyMeasurementRepo.GetBodyMeasurementById(id);

            if (measurement == null)
                return null;

            return new BodyMeasurementDTOs.BodyMeasurementDetailsDTO
            {
                measurementId = measurement.measurementId,
                memberName = measurement.Member.fullName,
                measurementDate = measurement.measurementDate,
                weight = measurement.weight,
                bodyFatPercentage = measurement.bodyFatPercentage,
                waistCircumference = measurement.waistCircumference,
                hipCircumference = measurement.hipCircumference,
                chestCircumference = measurement.chestCircumference,
                armCircumference = measurement.armCircumference,
                thighCircumference = measurement.thighCircumference,
                notes = measurement.notes
            };
        }

        // Create body measurement
        public async Task CreateBodyMeasurement(BodyMeasurementDTOs.BodyMeasurementInputDTO dto)
        {
            BodyMeasurement measurement = new BodyMeasurement
            {
                memberId = dto.memberId,
                measurementDate = dto.measurementDate,
                weight = dto.weight,
                bodyFatPercentage = dto.bodyFatPercentage,
                waistCircumference = dto.waistCircumference,
                hipCircumference = dto.hipCircumference,
                chestCircumference = dto.chestCircumference,
                armCircumference = dto.armCircumference,
                thighCircumference = dto.thighCircumference,
                notes = dto.notes
            };

            await _bodyMeasurementRepo.CreateBodyMeasurement(measurement);
        }

        // Update body measurement
        public async Task<bool> UpdateBodyMeasurement(int id, BodyMeasurementDTOs.BodyMeasurementInputDTO dto)
        {
            var measurement = await _bodyMeasurementRepo.GetBodyMeasurementById(id);

            if (measurement == null)
                return false;

            measurement.memberId = dto.memberId;
            measurement.measurementDate = dto.measurementDate;
            measurement.weight = dto.weight;
            measurement.bodyFatPercentage = dto.bodyFatPercentage;
            measurement.waistCircumference = dto.waistCircumference;
            measurement.hipCircumference = dto.hipCircumference;
            measurement.chestCircumference = dto.chestCircumference;
            measurement.armCircumference = dto.armCircumference;
            measurement.thighCircumference = dto.thighCircumference;
            measurement.notes = dto.notes;

            await _bodyMeasurementRepo.UpdateBodyMeasurement(measurement);

            return true;
        }

        // Delete body measurement
        public async Task<bool> DeleteBodyMeasurement(int id)
        {
            var measurement = await _bodyMeasurementRepo.GetBodyMeasurementById(id);

            if (measurement == null)
                return false;

            await _bodyMeasurementRepo.DeleteBodyMeasurement(id);

            return true;
        }
    }
}
