using System.ComponentModel.DataAnnotations;

namespace FitnessPlatform.DTOs
{
    // Register User
    public class RegisterDTO
    {
        [Required]
        [MaxLength(50)]
        public string username { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string email { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required]
        [MaxLength(20)]
        public string Role { get; set; }
        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////
        /// </summary>

        [Required(ErrorMessage = "Phone Number is required.")]
        [MaxLength(15)]
        public string phoneNumber { get; set; }//  user input  

        [Required(ErrorMessage = "Date of birth is required.")]
        public DateTime dateOfBirth { get; set; }//  user input

        [Required(ErrorMessage = "Gender is required.")]
        [MaxLength(10)]
        public string gender { get; set; }//  user input

        [Required(ErrorMessage = "height is required.")]
        [Range(50, 250,
           ErrorMessage = "Height must be between 50 and 250 cm.")]
        public double height { get; set; }//  user input

        [Required(ErrorMessage = "Weight is required.")]
        [Range(20, 300,
          ErrorMessage = "Weight must be between 20 and 300 kg.")]
        public double currentWeight { get; set; }//user input


    }
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public string Password { get; set; }
    }
    public class UpdateUserDTO
    {
        [Required]
        [MaxLength(50)]
        public string userName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string email { get; set; }
    }
    public class UserOutputDTO
    {
        public int userId { get; set; }

        public string userName { get; set; }

        public string email { get; set; }

        public string Role { get; set; }
    }
    public class UserDetailsDTO
    {
        public int userId { get; set; }

        public string userName { get; set; }

        public string email { get; set; }

        public string Role { get; set; }

        public bool isActive { get; set; }

        public DateTime createdAt { get; set; }
    }
    public class LoginResponseDTO
    {
        public string Token { get; set; }

        public string userName { get; set; }

        public string Role { get; set; }
    }
}
