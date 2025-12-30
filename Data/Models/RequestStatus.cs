using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DayOffMini.Data.Models
{
    public class RequestStatus
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Request> Requests { get; set; } = new HashSet<Request>();
    }
}
