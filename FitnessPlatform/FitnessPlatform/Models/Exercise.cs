using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessPlatform.Models
{

    [Table("Exercises")]
    public class Exercise
    {
        // Primary Key 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int exerciseId { get; set; } //System Generated

        [Required(ErrorMessage = "Exercise name is required.")]
        [MaxLength(100)]
        public string exerciseName { get; set; } // user input 

        [Required(ErrorMessage = "Target muscle is required.")] 
        [MaxLength(50)]
        public string targetMuscle { get; set; } // user input 

        // Optional
        [Url(ErrorMessage = "Invalid URL format.")]
        public string? videoUrl { get; set; } // user input 

        [Required]
        [MaxLength(50)]
        public string equipment {  get; set; } // user input 

        [Required]
        [MaxLength(20)]
        public string difficulityLevel { get; set; } // user input 

        //=========================================================
        // Navigation Properties
        public List<ProgramExercise> ProgramExercises { get; set; } // One Exercise can belong to many workout programs
    }
}
