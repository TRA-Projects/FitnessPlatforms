using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessPlatform.Models
{
    [Table("WorkoutPrograms")]
    public class WorkoutProgram
    {
        // Primary Key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int programId { get; set; }//system generated

        // Name of the workout program
        [Required(ErrorMessage = "Program name is required.")]
        [MaxLength(100, ErrorMessage = "Program name cannot exceed 100 characters.")]
        public string programName { get; set; }//user input


        // Stores the date when the workout program was created
        public DateTime createdAt { get; set; } = DateTime.Now;//system generated


        [Required(ErrorMessage = "Duration is required.")]
        [Range(1, 52, ErrorMessage = "Duration must be between 1 and 52 weeks.")]
        public int DurationInWeeks { get; set; }//user input


        [Required(ErrorMessage = "Goal is required.")]
        [MaxLength(200, ErrorMessage = "Goal cannot exceed 200 characters.")]
        public string Goal { get; set; }//user input



        [Required(ErrorMessage = "Member is required.")]
        [ForeignKey("Member")]
        public int memberId { get; set; }
        public Member Member { get; set; }// Navigation Properties



        [Required(ErrorMessage = "Trainer is required.")]
        [ForeignKey("Trainer")]
        public int trainerId { get; set; }
        public Trainer Trainer { get; set; }// Navigation Properties



        // One Workout Program contains many exercises
        public List<ProgramExercise>? ProgramExercises { get; set; }


        // One Workout Program can have many workout sessions
        public List<WorkoutSession>? WorkoutSessions { get; set; }
    }
}

