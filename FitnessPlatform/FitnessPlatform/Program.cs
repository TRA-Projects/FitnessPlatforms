
using FitnessPlatform.Repos;
using FitnessPlatform.Repos.Interfaces;
using FitnessPlatform.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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


            // Services
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<MemberService>();
            builder.Services.AddScoped<TrainerService>();
            builder.Services.AddScoped<MembershipPlanService>();
            builder.Services.AddScoped<ExerciseService>();
            builder.Services.AddScoped<ProgramExerciseService>();
            builder.Services.AddScoped<SubscriptionService>();
            builder.Services.AddScoped<WorkoutProgramService>();
            builder.Services.AddScoped<BodyMeasurementService>();
            builder.Services.AddScoped<NutritionPlanService>();
            builder.Services.AddScoped<WorkoutSessionService>();

            // JWT Authentication Service
            builder.Services.AddScoped<AuthService>();
            // Configure JWT Authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                JwtBearerDefaults.AuthenticationScheme;

                options.DefaultChallengeScheme =
                JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters =
                new TokenValidationParameters
                {
                    ValidateIssuer = true,

                    ValidateAudience = true,

                    ValidateLifetime = true,

                    ValidateIssuerSigningKey = true,


                    ValidIssuer =
                    builder.Configuration["JwtSettings:Issuer"],


                    ValidAudience =
                    builder.Configuration["JwtSettings:Audience"],


                    IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                        builder.Configuration["JwtSettings:SecretKey"]!)
                    )
                };
            });


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
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
