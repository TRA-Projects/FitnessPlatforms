using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessPlatform.Models
{
    [Table("Subscriptions")]
    public class Subscription
    {
        // Primary Key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int subscriptionId { get; set; }//System Generated

        // Stores the subscription start date
        [Required(ErrorMessage = "Start date is required.")]
        public DateTime startDate { get; set; } = DateTime.Now;//System Generated

        // StartDate + MembershipPlan.DurationInDays
        [Required(ErrorMessage = "End date is required.")]
        public DateTime EndDate { get; set; }//calculated


        // Indicates whether the subscription is active
        public bool IsActive { get; set; } = true;//default value


        //==============================
        // Navigation Properties
        //==============================
        [Required(ErrorMessage = "Member is required.")]
        [ForeignKey("Member")]
        public int memberId { get; set; }
        public Member Member { get; set; }  // Navigation Properties


        [Required(ErrorMessage = "Membership Plan is required.")]
        [ForeignKey("MembershipPlan")]
        public int planId { get; set; }
        public MembershipPlan MembershipPlan { get; set; }  // Navigation Properties
    }
}
