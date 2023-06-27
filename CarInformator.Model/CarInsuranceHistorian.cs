using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarInformator.Models.Historian
{
    [Table("Car Insurances")]
    public class CarInsuranceHistorian
    {
        [Key]
        public int Id { get; set; }
        public bool AccidentFree { get; set; }
        public string? DescAccident { get; set; }
        public int PrevOwner { get; set; }
        public int Milage { get; set; }

        public List<Car> InsuredCars { get; set; }
    }
}
