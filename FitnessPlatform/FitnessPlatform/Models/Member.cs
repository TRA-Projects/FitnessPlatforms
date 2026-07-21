using Microsoft.OpenApi.Expressions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessPlatform.Models
{
    // Stores personal information and fitness data
    [Table("Members")]
    public class Member
    { 
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int memberId { get; set; }// Primary Key Generated automatically by SQL Server (Identity)

        [Required(ErrorMessage = "Full Name is required.")]
        [MaxLength(100, ErrorMessage = "Maximum length is 100 characters.")]
        public string fullName { get; set; } //  user input  

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

        [Required]
        [Range(20, 300,
          ErrorMessage = "Weight must be between 20 and 300 kg.")]
        public double currentWeight { get; set; }//user input

        public DateTime joinDate { get; set; } = DateTime.Now;

      
        [Required]
        [ForeignKey("User")]
        public int userId {  get; set; }

        // Navigation Properties
        public  User User { get; set; }    // One User has one Member

        public List<Subscription>? Subscriptions { get; set; }  // One Member can have many subscriptions 

        public List<WorkoutProgram> ? WorkoutPrograms { get; set; }// One Member can have many workout programs

        public List<WorkoutSession>? WorkoutSessions { get; set; }  // One Member can attend many workout sessions

        public List<BodyExpression>? BodyExpressions { get; set; }  // One Member can have many body measurements

        public List<NutritionPlan>? NutritionPlans { get; set; } // One Member can have many nutrition plans

    }
}
