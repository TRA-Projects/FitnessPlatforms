using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessPlatform.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }   // Primary Key system generate

        [Required(ErrorMessage = "Username is required.")]
        [MaxLength(50, ErrorMessage = "Username cannot exceed 50 characters.")]
        public string userName { get; set; }//user input

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [MaxLength(150)]
        public string email { get; set; }//user input

        // The user enters a password during registration
        // The system hashes it using BCrypt before saving it
        // Never store the original password
        [Required]
        public string PasswordHash { get; set; }


        [Required]
        [MaxLength(20)]
        public string Role { get; set; } // Determines the user's permissions  Admin, Member, Trainer

        public bool isActive { get; set; } = true; //default value

        public DateTime createdAt { get; set; } = DateTime.Now;//system generate

        // Navigation Properties
        public Member? Member { get; set; } // One User can have one Member profile
        public Trainer? Trainer { get; set; }// One User can have one Trainer profile


    }
}
