using CarInformator.Models.Historian;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CarInformator.Models
{
    [Table("Cars")]
    public class Car
    {
        [Key]
        public int CarId { get; set; }

        public string Brand { get; set; }   

        public string Model { get; set; }

        public string Generation { get; set; }

        public int ProductionYear { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        [JsonIgnore]
        public List<CarRepairHistorian> CarRepairs { get; set; }  

        public List<CarInsuranceHistorian> InsuranceHistorians { get; set; }
    }
}
