using DayOffMini.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DayOffMini.Domain.Models
{
    public class LeaveBalance : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }
        public int TotalDaysRemaining { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual LeaveType LeaveType { get; set; } = null!;
    }
}
