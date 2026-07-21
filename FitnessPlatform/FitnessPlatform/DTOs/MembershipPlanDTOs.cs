using System.ComponentModel.DataAnnotations;

namespace FitnessPlatform.DTOs
{
    // =====================================
    // Used when creating a new membership plan
    // =====================================
    public class MembershipPlanDTOs
    {
        [Required(ErrorMessage = "Plan name is required.")]
        [MaxLength(50)]
        public string planName { get; set; }   // Entered by the Admin


        [Required(ErrorMessage = "Price is required.")]
        [Range(1, 10000, ErrorMessage = "Price must be greater than 0.")]
        public decimal price { get; set; }  // Entered by the Admin


        [Required(ErrorMessage = "Duration is required.")]
        [Range(1, 3650, ErrorMessage = "Duration must be greater than 0.")]
        public int durationInDays { get; set; }   // Entered by the Admin


        [MaxLength(500)]
        public string? description { get; set; }   // Entered by the Admin



        // =====================================
        // Used when displaying all membership plans
        // =====================================
        public class MembershipPlanOutputDTO
        {
           
            public int planId { get; set; } // Membership Plan ID

            
            public string planName { get; set; } // Membership Plan Name

            
            public decimal price { get; set; } // Membership Price
        }


    }
}
