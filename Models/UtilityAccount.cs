using System.ComponentModel.DataAnnotations;

namespace RentalMgtSystem.Models
{
    public class UtilityAccount
    {
        [Key]
        public int UtilityAccountID { get; set; }
        [Required]
        public string UtilityAccountNo { get; set; }
        public int? UnitID {  get; set; }
        public string? UtilityType { get; set; }
    }
}
