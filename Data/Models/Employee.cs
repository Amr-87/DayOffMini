using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DayOffMini.Data.Models
{
    public class Employee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Email { get; set; } = null!;
        public string? Name { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<LeaveRequest> LeaveRequests { get; set; } = new HashSet<LeaveRequest>();
        public virtual ICollection<LeaveBalance> LeaveBalances { get; set; } = new HashSet<LeaveBalance>();
    }
}
