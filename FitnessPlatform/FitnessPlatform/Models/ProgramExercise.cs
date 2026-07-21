using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessPlatform.Models
{
    [Table("ProgramExercises")]
    public class ProgramExercise
    {
        // Primary Key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int programExerciseId { get; set; } // System Generated

        [Required(ErrorMessage = "Number of sets is required.")]
        [Range(1, 20, ErrorMessage = "Sets must be between 1 and 20.")]
        public int sets {  get; set; } // user input 

        [Required(ErrorMessage = "Number of repetitions is required.")]
        [Range(1, 100, ErrorMessage = "Reps must be between 1 and 100.")]
        public int repetitions { get; set; } // user input 

        [Required(ErrorMessage = "Day of week is required.")]
        [MaxLength(20)]
        public string dayOfWeek { get; set; } // user input 

        [Required(ErrorMessage = "Rest time is required.")]
        [Range(10, 600, ErrorMessage = "Rest time must be between 10 and 600 seconds.")]
        public int restTime { get; set; } // user input 

        [Required]
        [ForeignKey("WorkoutProgram")]
        public int programId { get; set; } 

        [Required]
        [ForeignKey("Exercise")] 
        public int exerciseId { get; set; }

        //===========================================================
        // Navigation Properties
        public WorkoutProgram WorkoutProgram { get; set; } // One ProgramExercise belongs to one WorkoutProgram
        public Exercise Exercise { get; set; } // One ProgramExercise belongs to one Exercise

    }
}
