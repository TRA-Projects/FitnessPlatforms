using System.ComponentModel.DataAnnotations;

namespace FitnessPlatform.DTOs
{
    // ====== Used when adding an exercise to a program ======
    // POST Request

    public class ProgramExerciseInputDTO
    {
        // Foreign Key
        // Selected Workout Program
        [Required]
        public int programId { get; set; }


        // Foreign Key
        // Selected Exercise
        [Required]
        public int exerciseId { get; set; }

        // Number of sets
        [Required(ErrorMessage = "Number of sets is required.")]
        [Range(1, 20, ErrorMessage = "Sets must be between 1 and 20.")]
        public int sets { get; set; }

        // Number of repetitions
        [Required(ErrorMessage = "Number of repetitions is required.")]
        [Range(1, 100, ErrorMessage = "Reps must be between 1 and 100.")]
        public int repetitions { get; set; }

        // Day of week
        [Required(ErrorMessage = "Day of week is required.")]
        [MaxLength(20)]
        public string dayOfWeek { get; set; }

        // Rest time between sets in seconds
        [Required(ErrorMessage = "Rest time is required.")]
        [Range(10, 600, ErrorMessage = "Rest time must be between 10 and 600 seconds.")]
        public int restTime { get; set; }
    }


    // ====== Used when displaying program exercises ======
    // GET All

    public class ProgramExerciseOutputDTO
    {
        // System Generated
        public int programExerciseId { get; set; }


        // Display exercise name instead of ID
        public string exerciseName { get; set; }


        public int sets { get; set; }


        public int repetitions { get; set; }


        public string dayOfWeek { get; set; }


        public int restTime { get; set; }
    }


    // ====== Used when displaying one program exercise ======
    // GET By Id

    public class ProgramExerciseDetailsDTO
    {
        // System Generated
        public int programExerciseId { get; set; }


        // Foreign Key
        public int programId { get; set; }


        // Foreign Key
        public int exerciseId { get; set; }


        // Display exercise information
        public string exerciseName { get; set; }


        public int sets { get; set; }


        public int repetitions { get; set; }


        public string dayOfWeek { get; set; }


        public int restTime { get; set; }
    }
}
