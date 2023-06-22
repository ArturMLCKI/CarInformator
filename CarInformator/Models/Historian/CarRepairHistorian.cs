using System.ComponentModel.DataAnnotations;

namespace CarInformator.Models.Historian
{
    public class CarRepairHistorian
    {
        [Key]
        public int Id { get; set; }
        public string RepiarName { get; set; }
        public string RepiarDesc { get; set; }
        public decimal Price { get; set; }
        public string Date { get; set; }

        public int CarId { get; set; }
        public Car Cars { get; set; }


    }
}
