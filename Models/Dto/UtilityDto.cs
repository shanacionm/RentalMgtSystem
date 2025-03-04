using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace RentalMgtSystem.Models.Dto
{
    public class UtilityDto
    {
        public string? UtilityType { get; set; }
        public IEnumerable<SelectListItem> UtilityTypeValues => new List<SelectListItem>
        { 
            new SelectListItem{Text="Water",Value="Water" },
            new SelectListItem{Text="Electricity", Value="Electricity"}
        };
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? BillingDate { get; set; }
        public double? BillingAmount { get; set; }
        public double? MainMeterReading { get; set; }
        public double? SubmeterReading { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true, NullDisplayText = null)]
        public DateTime? PaymentDate { get; set; }
        public string? UtilityAccountNo { get; set; }
    }
}
