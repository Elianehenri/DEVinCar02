using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.DTOs;

public class DeliveryDTO
{
    public int Id { get; set; }
    public int? AddressId { get; set; }
    public DateTime? DeliveryForecast { get; set; }

    public DeliveryDTO()
    {
    }

    public DeliveryDTO(Delivery delivery)
    {
        AddressId = delivery.AddressId;
        DeliveryForecast = delivery.DeliveryForecast;
    }

    
}