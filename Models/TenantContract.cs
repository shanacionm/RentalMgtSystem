using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace RentalMgtSystem.Models
{
    public class TenantContract
    {
        [Key]
        public int ContractID { get; set; }
        [Required]
        public string TenantName { get; set; } = String.Empty;
        
        public double? RentalAmount { get; set; } 
        public string? UnitName { get; set; }
        public string? Details { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:MM-dd-yyyy}",ApplyFormatInEditMode =true)]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true,NullDisplayText =null)]

        public DateTime? DownpaymentDate { get; set; }
        public string? ElectricityBased { get; set; } = String.Empty;
        
    }
}
