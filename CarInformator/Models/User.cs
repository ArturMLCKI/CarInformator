namespace CarInformator.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int DrivingExp{ get; set; }

        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
