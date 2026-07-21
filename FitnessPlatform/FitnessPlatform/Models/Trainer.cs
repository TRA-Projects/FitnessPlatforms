


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessPlatform.Models
{
    [Table("Trainers")]
    public class Trainer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int traninerId { get; set; }  // Primary Key system generated


        [Required(ErrorMessage = "Full name is required.")]
        [MaxLength(100)]
        public string fullName { get; set; } // user input


        [Required(ErrorMessage = "Phone number is required.")]
        [MaxLength(15)]
        public string phoneNumber { get; set; } // user input


        [Required(ErrorMessage = "specialization is required.")]
        [MaxLength(100)]
        public string specialization { get; set; } // user input


        [Required(ErrorMessage = "yearsOfExperience is required.")]
        [Range(0, 50)]
        public int yearsOfExperience { get; set; } // user input


        [MaxLength(200)]
        public string? certification { get; set; } // user input


        [Required(ErrorMessage = "yearsOfExperience is required.")]
        [ForeignKey("User")]
        public int userId { get; set; }   // Foreign Key Value comes from the registered user account.


        // Navigation Properties
        public User User { get; set; }// One User has one Trainer profile

        public List<WorkoutProgram>? WorkoutPrograms { get; set; } // One Trainer can create many workout programs

        public List<NutritionPlan>? NutritionPlans { get; set; }     // One Trainer can create many nutrition plans









    }
}
