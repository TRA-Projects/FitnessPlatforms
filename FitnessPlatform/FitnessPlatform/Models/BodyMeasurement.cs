using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessPlatform.Models
{
    [Table("BodyMeasurements")]
    public class BodyMeasurement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int measurementId { get; set; } // System-generated 

        [Required(ErrorMessage = "Measurement date is required.")]
        public DateTime measurementDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Weight is required.")]
        [Range(20, 300, ErrorMessage = "Weight must be between 20 and 300 kg.")]
        public double weight { get; set; }

        [Required(ErrorMessage = "Body fat percentage is required.")]
        [Range(0, 100, ErrorMessage = "Body fat percentage must be between 0 and 100.")]
        public double bodyFatPercentage { get; set; }

        [Required(ErrorMessage = "Waist circumference is required.")]
        [Range(30, 250, ErrorMessage = "Waist circumference must be between 30 and 250 cm.")]
        public double waistCircumference { get; set; }

        // Optional
        // Entered by the trainer
        [Range(30, 250)]
        public double? hipCircumference { get; set; }

        // Optional
        // Entered by the trainer
        [Range(30, 250)]
        public double? chestCircumference { get; set; }

        // Optional
        // Entered by the trainer
        // Arm circumference measured in centimeters
        [Range(10, 100)]
        public double? armCircumference { get; set; }

        // Optional
        // Entered by the trainer
        // Thigh circumference measured in centimeters
        [Range(20, 150)]
        public double? thighCircumference { get; set; }

        // Optional
        // Entered by the trainer
        [MaxLength(500)]
        public string? notes { get; set; }

        [Required]
        [ForeignKey("Member")]
        public int memberId { get; set; }
        public Member Member { get; set; }  // Navigation property to the Member entity

    }
}
