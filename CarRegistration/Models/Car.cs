namespace CarRegistration.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        public string? RegistrationNumber { get; set; }
        public int? UserId { get; set; }
    }
}
