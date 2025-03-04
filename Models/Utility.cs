using System;
using System.ComponentModel.DataAnnotations;
namespace RentalMgtSystem.Models
{
    public class Utility
    {
        [Key]
        public int UtilityID { get; set; }
        public string? UtilityType { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? BillingDate { get; set; } 
        
        public double? BillingAmount { get; set; }
        public double? MainMeterReading { get; set; }
        public double? SubmeterReading { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true, NullDisplayText = null)]
        public DateTime? PaymentDate { get; set; }
        public string? UtilityAccountNo {  get; set; }
    }
}
