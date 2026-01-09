using System.ComponentModel.DataAnnotations.Schema;

namespace DayOffMini.Domain.DTOs
{
    public class LeaveTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsDefault { get; set; } = false;

        [Column(TypeName = "decimal(5,2)")]
        public decimal? DaysOffBalance { get; set; }
    }
}
