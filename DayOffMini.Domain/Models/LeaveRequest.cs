using DayOffMini.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DayOffMini.Domain.Models
{
    public class LeaveRequest : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }
        public int LeaveRequestStatusId { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal DurationInDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string? Reason { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual LeaveType LeaveType { get; set; } = null!;
        public virtual LeaveRequestStatus LeaveRequestStatus { get; set; } = null!;


    }
}
