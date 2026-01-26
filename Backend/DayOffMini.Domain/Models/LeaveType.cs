using DayOffMini.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DayOffMini.Domain.Models
{
    public class LeaveType : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public bool IsDefault { get; set; } = false;

        [Column(TypeName = "decimal(5,2)")]
        public decimal? DaysOffBalance { get; set; }

        public virtual ICollection<LeaveBalance> LeaveBalances { get; set; } = new HashSet<LeaveBalance>();
        public virtual ICollection<LeaveRequest> LeaveRequests { get; set; } = new HashSet<LeaveRequest>();
    }
}
