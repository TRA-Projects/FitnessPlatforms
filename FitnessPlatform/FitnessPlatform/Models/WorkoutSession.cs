using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessPlatform.Models
{
    [Table("WorkoutSessions")]
    public class WorkoutSession
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int sessionId { get; set; } // Sys Generated

        [Required]
        public DateTime sessionDate { get; set; } // Generated automatically by the system

        [Required]
        [Range(1, 300, ErrorMessage = "Duration must be between 1 and 300 minutes.")]
        public int DurationInMinutes { get; set; } //calculated by the system

        // Calculated automatically by the system based on the workout program and duration.
        [Range(0, 5000, ErrorMessage = "Calories burned must be between 0 and 5000.")]
        public int CaloriesBurned { get; set; }

        // Updated automatically by the system
        // True if the member completed the workout session.
        public bool IsCompleted { get; set; } = false;

     
        [Required]
        [ForeignKey("Member")]
        public int MemberId { get; set; }// Selected automatically when the member starts a workout session.
        public Member Member { get; set; } // Navigation property - One WorkoutSession belongs to one Member

        [Required]
        [ForeignKey("WorkoutProgram")]
        public int ProgramId { get; set; } // Selected from the assigned workout program.
        public WorkoutProgram WorkoutProgram { get; set; } // Navigation property - One WorkoutSession belongs to one WorkoutProgram

    }
}
