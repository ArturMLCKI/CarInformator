namespace CarInformator.Models.Historian
{
    public class CarInsuranceHistorian
    {
        public int Id { get; set; }
        public bool AccidentFree { get; set; }
        public int PrevOwner { get; set; }
        public int Milage { get; set; }
    }
}
