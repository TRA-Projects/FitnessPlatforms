using System.ComponentModel.DataAnnotations;

namespace FitnessPlatform.DTOs
{
    public class NutritionPlanInputDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string planName { get; set; }

        [Required]
        [Range(500, 10000)]
        public int dailyCalories { get; set; }

        [Required]
        [Range(0, 500)]
        public int proteinGrams { get; set; }

        [Required]
        [Range(0, 1000)]
        public int carbsGrams { get; set; }

        [Required]
        [Range(0, 300)]
        public int fatGrams { get; set; }

        [MaxLength(500)]
        public string? notes { get; set; }

        [Required]
        public int memberId { get; set; }

        [Required]
        public int trainerId { get; set; }
    }
    public class NutritionPlanOutputDTO
    {
        public int nutritionPlanId { get; set; }

        public string planName { get; set; }
        public string fullName { get; set; }

        public string trainerName { get; set; }

    }

    public class NutritionPlanDetailsDTO
    {
        public int nutritionPlanId { get; set; }

        public string planName { get; set; }

        public int dailyCalories { get; set; }

        public int proteinGrams { get; set; }

        public int carbsGrams { get; set; }

        public int fatGrams { get; set; }

        public string? notes { get; set; }

        public string memberName { get; set; }

        public string trainerName { get; set; }
    }
}