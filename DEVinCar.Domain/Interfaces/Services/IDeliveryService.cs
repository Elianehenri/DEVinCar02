using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;


namespace DEVinCar.Domain.Interfaces.Services
{
    public interface IDeliveryService
    {
        IList<Delivery> ObterTodos(int? addressId, int? saleId);//int? id, 
        DeliveryDTO ObterPorId(int id);
        
    }
}
