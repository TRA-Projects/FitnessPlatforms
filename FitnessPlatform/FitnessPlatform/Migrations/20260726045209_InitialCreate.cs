using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessPlatform.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    exerciseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    exerciseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    targetMuscle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    videoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    equipment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    difficulityLevel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.exerciseId);
                });

            migrationBuilder.CreateTable(
                name: "MembershipPlans",
                columns: table => new
                {
                    planId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    planName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    durationInDays = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipPlans", x => x.planId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    memberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    dateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    height = table.Column<double>(type: "float", nullable: false),
                    currentWeight = table.Column<double>(type: "float", nullable: false),
                    joinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.memberId);
                    table.ForeignKey(
                        name: "FK_Members_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    traninerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    specialization = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    yearsOfExperience = table.Column<int>(type: "int", nullable: false),
                    certification = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.traninerId);
                    table.ForeignKey(
                        name: "FK_Trainers_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BodyMeasurements",
                columns: table => new
                {
                    measurementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    measurementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    weight = table.Column<double>(type: "float", nullable: false),
                    bodyFatPercentage = table.Column<double>(type: "float", nullable: false),
                    waistCircumference = table.Column<double>(type: "float", nullable: false),
                    hipCircumference = table.Column<double>(type: "float", nullable: true),
                    chestCircumference = table.Column<double>(type: "float", nullable: true),
                    armCircumference = table.Column<double>(type: "float", nullable: true),
                    thighCircumference = table.Column<double>(type: "float", nullable: true),
                    notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    memberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyMeasurements", x => x.measurementId);
                    table.ForeignKey(
                        name: "FK_BodyMeasurements_Members_memberId",
                        column: x => x.memberId,
                        principalTable: "Members",
                        principalColumn: "memberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    subscriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    memberId = table.Column<int>(type: "int", nullable: false),
                    planId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.subscriptionId);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Members_memberId",
                        column: x => x.memberId,
                        principalTable: "Members",
                        principalColumn: "memberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_MembershipPlans_planId",
                        column: x => x.planId,
                        principalTable: "MembershipPlans",
                        principalColumn: "planId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NutritionPlans",
                columns: table => new
                {
                    nutritionPlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    planName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    dailyCalories = table.Column<int>(type: "int", nullable: false),
                    proteinGrams = table.Column<int>(type: "int", nullable: false),
                    notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    carbsGrams = table.Column<int>(type: "int", nullable: false),
                    fatGrams = table.Column<int>(type: "int", nullable: false),
                    memberId = table.Column<int>(type: "int", nullable: false),
                    trainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionPlans", x => x.nutritionPlanId);
                    table.ForeignKey(
                        name: "FK_NutritionPlans_Members_memberId",
                        column: x => x.memberId,
                        principalTable: "Members",
                        principalColumn: "memberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NutritionPlans_Trainers_trainerId",
                        column: x => x.trainerId,
                        principalTable: "Trainers",
                        principalColumn: "traninerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutPrograms",
                columns: table => new
                {
                    programId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    programName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationInWeeks = table.Column<int>(type: "int", nullable: false),
                    Goal = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    memberId = table.Column<int>(type: "int", nullable: false),
                    trainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutPrograms", x => x.programId);
                    table.ForeignKey(
                        name: "FK_WorkoutPrograms_Members_memberId",
                        column: x => x.memberId,
                        principalTable: "Members",
                        principalColumn: "memberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutPrograms_Trainers_trainerId",
                        column: x => x.trainerId,
                        principalTable: "Trainers",
                        principalColumn: "traninerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProgramExercises",
                columns: table => new
                {
                    programExerciseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sets = table.Column<int>(type: "int", nullable: false),
                    repetitions = table.Column<int>(type: "int", nullable: false),
                    dayOfWeek = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    restTime = table.Column<int>(type: "int", nullable: false),
                    programId = table.Column<int>(type: "int", nullable: false),
                    exerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramExercises", x => x.programExerciseId);
                    table.ForeignKey(
                        name: "FK_ProgramExercises_Exercises_exerciseId",
                        column: x => x.exerciseId,
                        principalTable: "Exercises",
                        principalColumn: "exerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramExercises_WorkoutPrograms_programId",
                        column: x => x.programId,
                        principalTable: "WorkoutPrograms",
                        principalColumn: "programId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutSessions",
                columns: table => new
                {
                    sessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sessionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    durationInMinutes = table.Column<int>(type: "int", nullable: false),
                    caloriesBurned = table.Column<int>(type: "int", nullable: false),
                    isCompleted = table.Column<bool>(type: "bit", nullable: false),
                    memberId = table.Column<int>(type: "int", nullable: false),
                    programId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutSessions", x => x.sessionId);
                    table.ForeignKey(
                        name: "FK_WorkoutSessions_Members_memberId",
                        column: x => x.memberId,
                        principalTable: "Members",
                        principalColumn: "memberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutSessions_WorkoutPrograms_programId",
                        column: x => x.programId,
                        principalTable: "WorkoutPrograms",
                        principalColumn: "programId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BodyMeasurements_memberId",
                table: "BodyMeasurements",
                column: "memberId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_userId",
                table: "Members",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NutritionPlans_memberId",
                table: "NutritionPlans",
                column: "memberId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionPlans_trainerId",
                table: "NutritionPlans",
                column: "trainerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramExercises_exerciseId",
                table: "ProgramExercises",
                column: "exerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramExercises_programId",
                table: "ProgramExercises",
                column: "programId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_memberId",
                table: "Subscriptions",
                column: "memberId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_planId",
                table: "Subscriptions",
                column: "planId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_userId",
                table: "Trainers",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPrograms_memberId",
                table: "WorkoutPrograms",
                column: "memberId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPrograms_trainerId",
                table: "WorkoutPrograms",
                column: "trainerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSessions_memberId",
                table: "WorkoutSessions",
                column: "memberId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSessions_programId",
                table: "WorkoutSessions",
                column: "programId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodyMeasurements");

            migrationBuilder.DropTable(
                name: "NutritionPlans");

            migrationBuilder.DropTable(
                name: "ProgramExercises");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "WorkoutSessions");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "MembershipPlans");

            migrationBuilder.DropTable(
                name: "WorkoutPrograms");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
