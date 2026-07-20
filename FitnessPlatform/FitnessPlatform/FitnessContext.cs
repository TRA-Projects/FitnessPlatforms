using Microsoft.EntityFrameworkCore;

namespace FitnessPlatform
{
    public class FitnessContext:DbContext
    {
        public FitnessContext(DbContextOptions<FitnessContext> options) : base(options) { }
    }
}
