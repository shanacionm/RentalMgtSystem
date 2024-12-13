using System;
using System.ComponentModel.DataAnnotations;
namespace RentalMgtSystem.Models
{
    public class Utility
    {
        [Key]
        public int UtilityID { get; set; }
        public string? UtilityType { get; set; }
        
        public DateTime? BillingDate{ get; set; }
        
        public double? MainMeterReading { get; set; }
        public double? SubmeterReading { get; set; } 

        public DateTime? PaymentDate { get; set; }
    }
}
