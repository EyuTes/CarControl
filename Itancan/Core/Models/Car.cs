namespace Itancan.Core.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string CarModel { get; set; }
        public CarStatus CarStatus { get; set; }
    }
}