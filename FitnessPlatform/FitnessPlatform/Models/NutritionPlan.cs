using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessPlatform.Models
{
    [Table("NutritionPlans")]
    public class NutritionPlan
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int nutritionPlanId { get; set; } //System-generated .

        [Required(ErrorMessage = "plan name is required.")]
        [MaxLength(100)]
        public string planName { get; set; }

        // entered by the trainer
        [Required(ErrorMessage = "daily calories are required.")]
        [Range(500, 10000, ErrorMessage = "daily calories must be between 500 and 10000.")]
        public int dailyCalories { get; set; }

        // entered by the trainer
        [Required(ErrorMessage = "protein grams are required.")]
        [Range(0, 500, ErrorMessage = "protein grams must be between 0 and 500.")]
        public int proteinGrams { get; set; }

        // optional
        // entered by the trainer
        [MaxLength(500)]
        public string? notes { get; set; }

        [Required(ErrorMessage = "carbs grams are required.")]
        [Range(0, 1000, ErrorMessage = "carbs grams must be between 0 and 1000.")]
        public int carbsGrams { get; set; }

        [Required(ErrorMessage = "fat grams are required.")]
        [Range(0, 300, ErrorMessage = "fat grams must be between 0 and 300.")]
        public int fatGrams { get; set; }


        [Required(ErrorMessage = "member is required.")]
        [ForeignKey("Member")]
        public int memberId { get; set; }
        public Member Member { get; set; }

        [Required(ErrorMessage = "trainer is required.")]
        [ForeignKey("Trainer")]
        public int trainerId { get; set; }  //navigation properties- one nutrition plan belongs to one member
        public Trainer Trainer { get; set; } //navigation properties- one nutrition plan belongs to one trainer


    }
}
