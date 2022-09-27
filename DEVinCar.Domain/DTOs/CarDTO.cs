using DEVinCar.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Api.DTOs
{
    public class CarDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The name is required")]
        [MaxLength(255)]
        public string Name { get; set; }
        public decimal SuggestedPrice { get; set; }

        public CarDTO()
        {
        }

        public CarDTO(Car car)
        {
            Id = car.Id;
            Name = car.Name;
            SuggestedPrice = car.SuggestedPrice;
        }

        public CarDTO(int id, string name, decimal suggestedPrice)
        {
            Id = id;
            Name = name;
            SuggestedPrice = suggestedPrice;
        }
    }
}
