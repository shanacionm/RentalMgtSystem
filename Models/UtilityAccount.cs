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
        public UtilityType UtilityType { get; set; }
        public Unit? Unit { get; set; }
    }
    public enum UtilityType
    {
        Electricity,
        Water
    }

}
