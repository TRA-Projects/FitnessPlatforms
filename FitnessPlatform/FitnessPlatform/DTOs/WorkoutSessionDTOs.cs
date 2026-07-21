using System.ComponentModel.DataAnnotations;

namespace FitnessPlatform.DTOs
{
    public class WorkoutSessionInputDTO
    {
        [Required]
        public int memberId { get; set; }

        [Required]
        public int programId { get; set; }

        [Required]
        [Range(1, 300, ErrorMessage = "Duration must be between 1 and 300 minutes.")]
        public int durationInMinutes { get; set; }
    }

    public class WorkoutSessionOutputDTO
    {
        public int sessionId { get; set; }

        public DateTime sessionDate { get; set; }

        public string fullName { get; set; }

        public string programName { get; set; }

        public bool isCompleted { get; set; }
    }

    public class WorkoutSessionDetailDTO
    {
        public int sessionId { get; set; }

        public DateTime sessionDate { get; set; }

        public int durationInMinutes { get; set; }

        public int caloriesBurned { get; set; }

        public bool isCompleted { get; set; }

        public string fullName { get; set; }

        public string programName { get; set; }
    }
}
