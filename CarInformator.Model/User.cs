using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarInformator.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public int DrivingExp{ get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
