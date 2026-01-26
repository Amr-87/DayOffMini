using DayOffMini.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DayOffMini.Domain.Models
{
    public class Employee : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(256)]
        public string? Email { get; set; }
        public virtual ICollection<LeaveRequest> LeaveRequests { get; set; } = new HashSet<LeaveRequest>();
        public virtual ICollection<LeaveBalance> LeaveBalances { get; set; } = new HashSet<LeaveBalance>();
    }
}
