using System.ComponentModel.DataAnnotations;

namespace FitnessPlatform.DTOs
{
    // Used when creating a new member
    public class MemberInputDTOs
    {
        [Required]
        public int userId { get; set; }

        [Required]
        [MaxLength(100)]
        public string fullName { get; set; }

        [Required]
        public string phoneNumber { get; set; }

        [Required]
        public DateTime dateOfBirth { get; set; }

        [Required]
        public string gender { get; set; }

        [Required]
        [Range(50, 250)]
        public double height { get; set; }

        [Required]
        [Range(20, 300)]
        public double currentWeight { get; set; }

    }
    // Used when displaying all members
    public class MemberOutputDTOs
    {
        public int memberId { get; set; }

        public string fullName { get; set; }

        public string phoneNumber { get; set; }
    }
    // Used when displaying member details
    public class MemberDetailsDTO
    {
        public int memberId { get; set; }

        public string fullName { get; set; }

        public string phoneNumber { get; set; }

        public DateTime dateOfBirth { get; set; }

        public string gender { get; set; }

        public double height { get; set; }

        public double currentWeight { get; set; }

        public DateTime joinDate { get; set; }

        public string email { get; set; }
    }
}
