using System.ComponentModel.DataAnnotations.Schema;

namespace DayOffMini.Domain.DTOs.UpdateRequests
{
    public class UpdateLeaveTypeDto
    {
        public string Name { get; set; } = null!;
        public bool IsDefault { get; set; } = false;

        [Column(TypeName = "decimal(5,2)")]
        public decimal? DaysOffBalance { get; set; }
    }
}
