using FitnessPlatform.Models;
using FitnessPlatform.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessPlatform.Repos
{
    public class BodyMeasurementRepo : IBodyMeasurementRepository
    {
        private readonly FitnessContext _context;


        public BodyMeasurementRepo(FitnessContext context)
        {
            _context = context;
        }

        //==========================
        // Get all body measurements
        public async Task<IEnumerable<BodyMeasurement>> GetAllBodyMeasurements()
        {
            return await _context.BodyMeasurements
                .Include(b => b.Member)
                .ToListAsync();
        }

        //==========================
        // Get body measurement by id
        public async Task<BodyMeasurement?> GetBodyMeasurementById(int id)
        {
            return await _context.BodyMeasurements
                .Include(b => b.Member)
                .FirstOrDefaultAsync(b => b.measurementId == id);
        }

        //==========================
        // Get all measurements for specific member
        public async Task<IEnumerable<BodyMeasurement>> GetMeasurementsByMemberId(
            int memberId)
        {
            return await _context.BodyMeasurements
                .Where(b => b.memberId == memberId)
                .ToListAsync();
        }

        //==========================
        // Create new body measurement
        public async Task<BodyMeasurement> CreateBodyMeasurement(
            BodyMeasurement bodyMeasurement)
        {
            _context.BodyMeasurements.Add(bodyMeasurement);

            await _context.SaveChangesAsync();

            return bodyMeasurement;
        }

        //==========================
        // Update body measurement
        public async Task UpdateBodyMeasurement(
            BodyMeasurement bodyMeasurement)
        {
            _context.BodyMeasurements.Update(bodyMeasurement);

            await _context.SaveChangesAsync();
        }

        //==========================
        // Delete body measurement
        public async Task DeleteBodyMeasurement(int id)
        {
            var measurement = await GetBodyMeasurementById(id);

            if (measurement != null)
            {
                _context.BodyMeasurements.Remove(measurement);

                await _context.SaveChangesAsync();
            }
        }

    }
}
