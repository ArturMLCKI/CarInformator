using System.ComponentModel.DataAnnotations;

namespace CarInformator.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public int DrivingExp{ get; set; }

    }
}
