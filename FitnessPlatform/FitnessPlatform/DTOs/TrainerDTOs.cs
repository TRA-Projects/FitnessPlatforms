using System.ComponentModel.DataAnnotations;

namespace FitnessPlatform.DTOs
{
    public class TrainerInputDTOs
    {
        [Required]
        public int userId { get; set; }


        [Required(ErrorMessage = "Full name is required.")]
        [MaxLength(100)]
        public string fullName { get; set; } // User Input


        [Required(ErrorMessage = "Phone number is required.")]
        [MaxLength(15)]
        public string phoneNumber { get; set; } // User Input



        [Required(ErrorMessage = "specialization is required.")]
        [MaxLength(100)]
        public string specialization { get; set; }    // User Input


        [Required(ErrorMessage = "Years of experience is required.")]
        [Range(0, 50)]
        public int yearsOfExperience { get; set; }    // User Input


        [MaxLength(200)]
        public string? certification { get; set; }    // User Input

    }
    // =====================================
    // Used when displaying all trainers
    // =====================================

    public class TrainerOutputDTOs
    {
        public int trainerId { get; set; }

        public string fullName { get; set; }

        public string specialization { get; set; }


    }
}
