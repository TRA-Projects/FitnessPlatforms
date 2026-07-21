using System.ComponentModel.DataAnnotations;

namespace FitnessPlatform.DTOs
{
    public class WorkoutProgramInputDTO
    {
        [Required(ErrorMessage = "Program name is required.")]
        [MaxLength(100)]
        public string programName { get; set; }



        [Required(ErrorMessage = "Duration is required.")]
        [Range(1, 52)]
        public int DurationInWeeks { get; set; }

        [Required(ErrorMessage = "Goal is required.")]
        [MaxLength(200)]
        public string Goal { get; set; }



        [Required(ErrorMessage = "Member is required.")]
        public int memberId { get; set; }



        [Required(ErrorMessage = "Trainer is required.")]
        public int trainerId { get; set; }

    }
    public class WorkoutProgramOutputDTO
    {

        public int programId { get; set; }


        public string programName { get; set; }


        public string memberName { get; set; }



        public string trainerName { get; set; }



        public int DurationInWeeks { get; set; }


        public string Goal { get; set; }

    }
    public class WorkoutProgramDetailsDTO
    {

        public int programId { get; set; }



        public string programName { get; set; }


        public DateTime createdAt { get; set; }


        public int DurationInWeeks { get; set; }


        public string Goal { get; set; }


        public string memberName { get; set; }



        public string trainerName { get; set; }

    }

}
