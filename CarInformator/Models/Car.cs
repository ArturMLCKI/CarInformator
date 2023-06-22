using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarInformator.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        public string Brand { get; set; }   

        public string Model { get; set; }

        public string Generation { get; set; }

        public int ProductionYear { get; set; }
        
        
    }
}
