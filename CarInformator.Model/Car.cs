using CarInformator.Models.Historian;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarInformator.Models
{
    [Table("Cars")]
    public class Car
    {
        [Key]
        public int Id { get; set; }

        public string Brand { get; set; }   

        public string Model { get; set; }

        public string Generation { get; set; }

        public int ProductionYear { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<CarRepairHistorian> CarRepairs { get; set; }  
    }
}
