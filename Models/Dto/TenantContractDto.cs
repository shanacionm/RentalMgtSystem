using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace RentalMgtSystem.Models.Dto
{
    public class TenantContractDto
    {
        public string? TenantName { get; set; } 
        
        public double? RentalAmount { get; set; }
        public string? UnitName { get; set; }
        public string? Details { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]

        public DateTime? EndDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]

        public DateTime? DownpaymentDate { get; set; }
        public string? ElectricityBased { get; set; } 
        public IEnumerable<SelectListItem>? ElectricityBasedValues => new List<SelectListItem>
        {          
            new SelectListItem{Value="Submeter", Text="Submeter"},
            new SelectListItem{Value="Main Meter", Text="Main Meter"}
        };
    }
}
