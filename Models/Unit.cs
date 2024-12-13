using System.ComponentModel.DataAnnotations;

namespace RentalMgtSystem.Models
{
    public class Unit
    {
        [Key]
        public int UnitID { get; set; }
        public string ? UnitName { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}

