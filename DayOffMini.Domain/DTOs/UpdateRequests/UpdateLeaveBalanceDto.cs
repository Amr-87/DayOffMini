using System.ComponentModel.DataAnnotations.Schema;

namespace DayOffMini.Domain.DTOs.UpdateRequests
{
    public class UpdateLeaveBalanceDto
    {
        public int LeaveTypeId { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal FixedDaysOffBalance { get; set; }
    }
}
