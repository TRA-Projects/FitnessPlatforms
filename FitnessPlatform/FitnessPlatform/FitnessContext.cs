using FitnessPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessPlatform
{
    public class FitnessContext:DbContext
    {
        public FitnessContext(DbContextOptions<FitnessContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<MembershipPlan> MembershipPlans { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<WorkoutProgram> WorkoutPrograms { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ProgramExercise> ProgramExercises { get; set; }
        public DbSet<WorkoutSession> WorkoutSessions { get; set; }
        public DbSet<BodyMeasurement> BodyMeasurements { get; set; }
        public DbSet<NutritionPlan> NutritionPlans { get; set; }










        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NutritionPlan>()
                .HasOne(np => np.Trainer)
                .WithMany(t => t.NutritionPlans)
                .HasForeignKey(np => np.trainerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkoutProgram>()
                .HasOne(wp => wp.Trainer)
                .WithMany(t => t.WorkoutPrograms)
                .HasForeignKey(wp => wp.trainerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkoutSession>()
       .HasOne(ws => ws.WorkoutProgram)
       .WithMany(wp => wp.WorkoutSessions)
       .HasForeignKey(ws => ws.programId)
       .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
