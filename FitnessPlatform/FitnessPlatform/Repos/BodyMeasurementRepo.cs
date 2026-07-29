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

        public async Task<IEnumerable<BodyMeasurement>> GetAllBodyMeasurements()
        {
            return await _context.BodyMeasurements
                .AsNoTracking()
                .Include(b => b.Member)
                .ToListAsync();
        }

        public async Task<BodyMeasurement?> GetBodyMeasurementById(int id)
        {
            return await _context.BodyMeasurements
                .Include(b => b.Member)
                .FirstOrDefaultAsync(b => b.measurementId == id);
        }

        public async Task<IEnumerable<BodyMeasurement>> GetMeasurementsByMemberId(int memberId)
        {
            return await _context.BodyMeasurements
                .AsNoTracking()
                .Include(b => b.Member)
                .Where(b => b.memberId == memberId)
                .ToListAsync();
        }

        public async Task<BodyMeasurement> CreateBodyMeasurement(BodyMeasurement bodyMeasurement)
        {
            _context.BodyMeasurements.Add(bodyMeasurement);
            await _context.SaveChangesAsync();
            return bodyMeasurement;
        }

        public async Task UpdateBodyMeasurement(BodyMeasurement bodyMeasurement)
        {
            _context.BodyMeasurements.Update(bodyMeasurement);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBodyMeasurement(int id)
        {
            var measurement = await _context.BodyMeasurements.FindAsync(id);

            if (measurement != null)
            {
                _context.BodyMeasurements.Remove(measurement);
                await _context.SaveChangesAsync();
            }
        }
    }
}