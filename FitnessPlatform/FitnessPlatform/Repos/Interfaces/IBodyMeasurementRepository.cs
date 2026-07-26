using FitnessPlatform.Models;

namespace FitnessPlatform.Repos.Interfaces
{
    public interface IBodyMeasurementRepository
    {
        // Get all body measurements
        Task<IEnumerable<BodyMeasurement>> GetAllBodyMeasurements();

        // Get body measurement by id
        Task<BodyMeasurement?> GetBodyMeasurementById(int id);

        // Get measurements by member id
        Task<IEnumerable<BodyMeasurement>> GetMeasurementsByMemberId(int memberId);

        // Create new body measurement
        Task<BodyMeasurement> CreateBodyMeasurement(
            BodyMeasurement bodyMeasurement);

        // Update body measurement
        Task UpdateBodyMeasurement(
            BodyMeasurement bodyMeasurement);

        // Delete body measurement
        Task DeleteBodyMeasurement(int id);

    }
}
