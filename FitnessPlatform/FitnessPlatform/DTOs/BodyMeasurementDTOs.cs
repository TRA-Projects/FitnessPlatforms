using System.ComponentModel.DataAnnotations;

namespace FitnessPlatform.DTOs
{
    public class BodyMeasurementDTOs
    {
        public class BodyMeasurementInputDTO
        {


            [Required(ErrorMessage = "Measurement date is required.")]
            public DateTime measurementDate { get; set; }


            [Required(ErrorMessage = "Weight is required.")]
            [Range(20, 300)]
            public double weight { get; set; }



            [Required(ErrorMessage = "Body fat percentage is required.")]
            [Range(0, 100)]
            public double bodyFatPercentage { get; set; }



            [Required(ErrorMessage = "Waist circumference is required.")]
            [Range(30, 250)]
            public double waistCircumference { get; set; }


            [Range(30, 250)]
            public double? hipCircumference { get; set; }


            [Range(30, 250)]
            public double? chestCircumference { get; set; }


            [Range(10, 100)]
            public double? armCircumference { get; set; }



            [Range(20, 150)]
            public double? thighCircumference { get; set; }


            [MaxLength(500)]
            public string? notes { get; set; }


            [Required(ErrorMessage = "Member is required.")]
            public int memberId { get; set; }

        }
        public class BodyMeasurementOutputDTO
        {


            public int measurementId { get; set; }



            public string memberName { get; set; }


            public DateTime measurementDate { get; set; }


            public double weight { get; set; }


            public double bodyFatPercentage { get; set; }



            public double waistCircumference { get; set; }

        }
        public class BodyMeasurementDetailsDTO
        {


           
            public int measurementId { get; set; }


            public string memberName { get; set; }


            public DateTime measurementDate { get; set; }


            public double weight { get; set; }


            public double bodyFatPercentage { get; set; }


            public double waistCircumference { get; set; }


            public double? hipCircumference { get; set; }

            public double? chestCircumference { get; set; }

            public double? armCircumference { get; set; }

            public double? thighCircumference { get; set; }

            public string? notes { get; set; }

        }

    }
}
