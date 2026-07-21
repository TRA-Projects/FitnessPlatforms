using System.ComponentModel.DataAnnotations;

namespace FitnessPlatform.DTOs
{
    public class SubscriptionDTOs
    {
        // =====================================
        // Used when creating a new subscription
        // =====================================
        public class SubscriptionInputDTO
        {
            [Required(ErrorMessage = "Member is required.")]
            public int memberId { get; set; }


            [Required(ErrorMessage = "Membership plan is required.")]
            public int planId { get; set; }
        }

        // =====================================
        // Used when displaying all subscriptions
        // =====================================
        public class SubscriptionOutputDTO
        {
            public int subscriptionId { get; set; }


            public string fullName { get; set; }


            public string planName { get; set; }


            public bool IsActive { get; set; }
        }

        // =====================================
        // Used when displaying subscription details
        // =====================================
        public class SubscriptionDetailsDTO
        {
            public int subscriptionId { get; set; }



            public string fullName { get; set; }



            public string planName { get; set; }



            public decimal price { get; set; }



            public int durationInDays { get; set; }



            public DateTime startDate { get; set; }


            public DateTime EndDate { get; set; }



            public bool IsActive { get; set; }
        }
    }
}
