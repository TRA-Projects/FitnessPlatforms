
using FitnessPlatform.Repos;
using FitnessPlatform.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessPlatform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Register Database Context
            builder.Services.AddDbContext<FitnessContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


           
            // Register Repositories

            builder.Services.AddScoped<IUserRepository, UserRepo>();

            builder.Services.AddScoped<IMemberRepository, MemberRepo>();

            builder.Services.AddScoped<IExerciseRepository, ExerciseRepo>();

            builder.Services.AddScoped<IProgramExerciseRepository, ProgramExerciseRepo>();

            builder.Services.AddScoped<ITrainerRepository, TrainerRepo>();

            builder.Services.AddScoped<IMembershipPlanRepository, MembershipPlanRepo>();

            builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepo>();

            builder.Services.AddScoped<IWorkoutProgramRepository, WorkoutProgramRepo>();

            builder.Services.AddScoped<IBodyMeasurementRepository, BodyMeasurementRepo>();

            builder.Services.AddScoped<INutritionPlanRepository, NutritionPlanRepo>();

            builder.Services.AddScoped<IWorkoutSessionRepository, WorkoutSessionRepo>();

            // Swagger Services
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
