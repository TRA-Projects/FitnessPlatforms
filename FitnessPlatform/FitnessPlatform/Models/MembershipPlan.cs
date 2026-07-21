using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessPlatform.Models
{
    [Table("MembershipPlans")]
    public class MembershipPlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int planId { get; set; } // Primary Key system generated

        [Required(ErrorMessage = "planname is required.")]
        [MaxLength(50)]
        public string planName { get; set; } // Entered by the Admin Monthly, Yearly, VIP

        [Required(ErrorMessage = "price is required.")]
        [Range(1, 10000)]
        public decimal price { get; set; }  // Entered by the Admin Membership price

        [Required(ErrorMessage = "durationInDays is required.")]
        [Range(1, 3650)]
        public int durationInDays { get; set; }   // Entered by the Admin Duration in days

        [MaxLength(500)]
        public string? Description { get; set; }  // Entered by the


        // Navigation Properties
        public List<Subscription>? Subscriptions { get; set; } // One Membership Plan can have many subscriptions

    }
}
