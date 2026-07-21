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
