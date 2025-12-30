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

        public virtual ICollection<Request> Requests { get; set; } = new HashSet<Request>();
        public virtual ICollection<Balance> Balances { get; set; } = new HashSet<Balance>();

    }
}
