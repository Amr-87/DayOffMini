using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DayOffMini.Data.Models
{
    public class LeaveType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Balance> Balances { get; set; } = new HashSet<Balance>();
        public virtual ICollection<Request> Requests { get; set; } = new HashSet<Request>();
    }
}
