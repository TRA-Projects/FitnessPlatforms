using System.ComponentModel.DataAnnotations;

namespace FitnessPlatform.DTOs
{

    // ====== Used when creating a new exercise ======

    public class ExerciseInputDTO
    {
        // Exercise name entered by trainer/admin
        [Required(ErrorMessage = "Exercise name is required.")]
        [MaxLength(100)]
        public string exerciseName { get; set; }


        // Target muscle entered by trainer/admin
        // Example: Chest, Back, Legs
        [Required(ErrorMessage = "Target muscle is required.")]
        [MaxLength(50)]
        public string targetMuscle { get; set; }


        // Optional video link entered by trainer
        [Url(ErrorMessage = "Invalid URL format.")]
        public string? videoUrl { get; set; }


        // Type of equipment needed for exercise
        // Example: Dumbbell, Machine, Body Weight
        [Required]
        [MaxLength(50)]
        public string erquipment { get; set; }


        // Exercise difficulty level
        // Example: Beginner, Intermediate, Advanced
        [Required]
        [MaxLength(20)]
        public string difficultyLevel { get; set; }
    }



    // ====== Used when displaying all exercises ======

    public class ExerciseOutputDTO
    {
        // Primary Key
        public int exerciseId { get; set; }


        public string exerciseName { get; set; }


        public string targetMuscle { get; set; }


        public string equipment { get; set; }


        public string difficultyLevel { get; set; }
    }


    // ====== Used when displaying exercise details ======

    public class ExerciseDetailsDTO
    {
        public int exerciseId { get; set; }


        public string exerciseName { get; set; }


        public string targetMuscle { get; set; }


        public string? videoUrl { get; set; }


        public string equipment { get; set; }


        public string difficultyLevel { get; set; }
    }
}
