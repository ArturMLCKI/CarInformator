using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CarInformator.Models.Historian
{
    [Table("CarRepairs")]
    public class CarRepairHistorian
    {
        [Key]
        public int Id { get; set; }
        public string RepiarName { get; set; }
        public string RepiarDesc { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("Car")]
        public int? CarId { get; set; }
        public Car RepairedCars { get; set; }


    };
}
